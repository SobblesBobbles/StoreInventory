using Newtonsoft.Json;
using StoreInventory.BLL.Interfaces;
using StoreInventory.DAL.Context;
using StoreInventory.DAL.Utilities;
using StoreInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StoreInventory.BLL
{

    public class DataManager : IDataManager
    {
        private UnitOfWork _UnitOfWork;
        public DataManager()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public StoreInventoryOverviewVm LoadView ()
        {
            StoreInventoryOverviewVm vm = new StoreInventoryOverviewVm();
            var DataSearch = GetInventoryDataFromDatabase();
            vm.StatisticItems = DataSearch.StatisticItems;
            vm.Analysis = DataSearch.Analysis;
            vm.InventoryCsv = ReadFile();
            return vm;
        }
        public StoreInventoryOverviewVm GetInventoryDataFromDatabase ()
        {
            StoreInventoryOverviewVm vm = new StoreInventoryOverviewVm();
            var InventoryItems = _UnitOfWork.StoreInventoryRepository.GetAll().Select(s=> new InventoryItem
            {
                Date = s.Date,
                Price = s.Price
            }).ToList();

            TimeSpan result = new TimeSpan(0);
            string fromTimeString = result.ToString("hh':'mm");
        
            var MostImportantTime = InventoryItems.AsEnumerable()
                  .GroupBy(row => row.Date.Hour)
                  .Select(grp => new TimeStatisticsVm
                  {
                      HourOfDay = grp.Key,
                      NoOfItems = grp.Count(),
                      TotalPriceForTheHour = grp.Sum(s => s.Price)
                  }).OrderByDescending(o => o.TotalPriceForTheHour).ToList();

            foreach (var item in MostImportantTime)
            {
                TimeSpan time = TimeSpan.FromHours(item.HourOfDay);       
                item.TimeOfDayFormatted = time.ToString("hh':'mm");
            }

            var Analysis = InventoryItems.Select(s => new
            {
                MaxPrice = InventoryItems.Max(m => m.Price),
                MinPrice = InventoryItems.Min(m => m.Price),
                AvgPrice = InventoryItems.Average(a => a.Price),
                ImportantTime = MostImportantTime.FirstOrDefault().TimeOfDayFormatted
            }).FirstOrDefault();

            vm.Analysis = JsonConvert.SerializeObject(Analysis);
            vm.StatisticItems = InventoryItems;
            return vm;
        }
        private CsvVm ReadFile()
        {
           List<InventoryItemCsv> values = File.ReadAllLines("C:\\Users\\Sobbles\\Desktop\\Projects\\StoreInventory\\DataExports\\Inventory.csv")
                               .Skip(1)
                               .Select(v => InventoryItemCsv.FromCsv(v))
                               .ToList();
            CsvVm Csv = new CsvVm();
            Csv.InventoryItemCsv = values;
            return Csv;
        }


        public CsvVm ReadFile(HttpPostedFileBase file)
        {
            string result;
            CsvVm Csv = new CsvVm();
            List<InventoryItemCsv> Items = new List<InventoryItemCsv>();
            if (file != null)
            {
                 List<string> values = new List<string>();
                using (StreamReader sr = new StreamReader(file.InputStream))
                {
                    sr.ReadLine();
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        List<string> lineValues = line.Split(',').ToList();

                            Items.Add(new InventoryItemCsv()
                            {
                                Date = Convert.ToDateTime(lineValues[0]),
                                Price = Convert.ToDecimal(lineValues[1])
                            });
                    }
                }
                Csv.InventoryItemCsv = Items;
            }
            return Csv;
        }

        public StoreInventoryOverviewVm FindDataByDates (DataRetrievalDto search)
        {

            StoreInventoryOverviewVm vm = new StoreInventoryOverviewVm();
            var results = _UnitOfWork.StoreInventoryRepository.Get(w => w.Date >= search.FromTime && w.Date <= search.ToTime)
                                    .Select(s=> new InventoryItem
                                    {
                                        Date = s.Date,
                                        Price = s.Price
                                    }).ToList();

            var Hours = results.GroupBy(D => D.Date.Date.Hour).ToList();

            var MostImportantTime = results.AsEnumerable()
            .GroupBy(row => row.Date.Hour)
            .Select(grp => new TimeStatisticsVm
            {
                HourOfDay = grp.Key,
                NoOfItems = grp.Count(),
                TotalPriceForTheHour = grp.Sum(s => s.Price)
            }).OrderByDescending(o => o.TotalPriceForTheHour).ToList();

            var Analysis = results.Select(s => new
            {
                MaxPrice = results.Max(m => m.Price),
                MinPrice = results.Min(m => m.Price),
                AvgPrice = results.Average(a => a.Price),
                ImportantTime = MostImportantTime.FirstOrDefault()

            }).FirstOrDefault();

            vm.Analysis = JsonConvert.SerializeObject(Analysis);
            vm.StatisticItems = results;

            return vm;
        }

        public bool StoreData (List<InventoryItem> data)
        {
            // Just so its not writing 3500 objects into memory
            DAL.EntityModels.StoreInventory TempItem = new DAL.EntityModels.StoreInventory();
            foreach (var item in data)
            {
                TempItem.Price = item.Price;
                TempItem.Date = item.Date;

                _UnitOfWork.StoreInventoryRepository.Insert(TempItem);
                _UnitOfWork.SaveChanges();
                TempItem.Price = 0;
                TempItem.Date = DateTime.Now;
            }
            return true;
        }
    }
}

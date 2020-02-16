using StoreInventory.BLL.Interfaces;
using StoreInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StoreInventory.Controllers
{
    public class StoreController : Controller
    {
        // GET: Inventory
        private IDataManager _DataManager;

        public StoreController(IDataManager _dataManager)
        {

            _DataManager = _dataManager;
        }


        public ActionResult Inventory()
        {
            StoreInventoryOverviewVm vm = new StoreInventoryOverviewVm();
              vm = _DataManager.LoadView();
            return View("Inventory", vm);
        }
        [HttpPost]
        public ActionResult BrowseFile(HttpPostedFileBase file)
        {
            var RefreshNewData = _DataManager.ReadFile(file);
            StoreInventoryOverviewVm vm = new StoreInventoryOverviewVm();
            var DatabaseData = _DataManager.GetInventoryDataFromDatabase();
            vm.InventoryCsv = RefreshNewData;
            vm.StatisticItems = DatabaseData.StatisticItems;

            return View("Inventory", vm);
        }


        public ActionResult ViewDataByDate (DataRetrievalDto search)
        {
            StoreInventoryOverviewVm vm = new StoreInventoryOverviewVm();
            vm = _DataManager.LoadView();
            var DataSearch = _DataManager.FindDataByDates(search);
            vm.Analysis = DataSearch.Analysis;
            vm.StatisticItems = DataSearch.StatisticItems;
            return PartialView("_DataSearch", vm);
        }

        [HttpPost]
        public ActionResult StoreData (List<InventoryItem> data)
        {
            var result = _DataManager.StoreData(data);

            return Inventory();
        }


    }
}
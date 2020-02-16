using StoreInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StoreInventory.BLL.Interfaces
{
    public interface IDataManager
    {
        StoreInventoryOverviewVm LoadView();
        CsvVm ReadFile(HttpPostedFileBase file);
        string GetInventoryDataFromDatabase();
        string FindDataByDates(DataRetrievalDto search); 
        bool StoreData(List<InventoryItem> data);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StoreInventory.ViewModels
{
    public class InventoryItemCsv : InventoryItem
    {

       
        public static InventoryItemCsv FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            InventoryItemCsv InventoryValues = new InventoryItemCsv();
            InventoryValues.Date = Convert.ToDateTime(values[0]);
            InventoryValues.Price = Convert.ToDecimal(values[1]);
     
            return InventoryValues;
        }
    }
}

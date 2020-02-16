using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StoreInventory.ViewModels
{
   public class CsvVm
    {
        public HttpPostedFileBase attachment { get; set; }

        public string FilePath { get; set; }

        public List<InventoryItemCsv> InventoryItemCsv { get; set; }
    }
}

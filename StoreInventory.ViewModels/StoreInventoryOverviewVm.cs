using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventory.ViewModels
{
    public class StoreInventoryOverviewVm
    {
        public string  InventoryDbItems{get; set;}
        public string Analysis { get; set; }
        public CsvVm  InventoryCsv { get; set; }


        [Required(ErrorMessage = "End date is required *")]
        public DateTime? ToTime { get; set; }



        [Required(ErrorMessage = "Start date is required *")]
        public DateTime? FromTime { get; set; }
    }
}

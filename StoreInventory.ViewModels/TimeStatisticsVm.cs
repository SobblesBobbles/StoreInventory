using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventory.ViewModels
{
  public  class TimeStatisticsVm
    {
        public int HourOfDay { get; set; }
        public int NoOfItems { get; set; }
        public decimal TotalPriceForTheHour { get; set; }
        public string TimeOfDayFormatted { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventory.ViewModels
{
   public class StatisticsVm
    {
        public string Analysis { get; set; }
        public List<InventoryItem> Items { get; set; }
    }
}

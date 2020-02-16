using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventory.DAL.EntityModels
{
    [Table("Store_Inventory_Tbl")]
   public class StoreInventory
   {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }
   }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreInventory.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DbConnection") { }
        public virtual DbSet<EntityModels.StoreInventory> StoreInventory { get; set; }
    }

}

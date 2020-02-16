using StoreInventory.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventory.DAL.Utilities
{
    public class UnitOfWork
    {


        private DatabaseContext _context;

        public UnitOfWork()
        {
            _context = new DatabaseContext();
        }


        private Repository<EntityModels.StoreInventory> _StoreInventoryRepository;



        public Repository<EntityModels.StoreInventory> StoreInventoryRepository
        {
            get
            {
                if (this._StoreInventoryRepository == null)
                {
                    this._StoreInventoryRepository = new Repository<EntityModels.StoreInventory>(_context);
                }
                return _StoreInventoryRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}

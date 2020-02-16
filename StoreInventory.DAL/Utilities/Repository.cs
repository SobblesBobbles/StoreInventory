using StoreInventory.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventory.DAL.Utilities
{
    public class Repository<T> where T : class
    {
        internal DatabaseContext _context;
        internal DbSet<T> _entities;
        public Repository(DatabaseContext context)
        {

            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        // Custom queries, taking an expression as a parameter, (T=>T.Attribute), returns a list.
        public virtual IEnumerable<T> Get
            (Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);

            }

            foreach (var IncludedProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(IncludedProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T obj)
        {
            _entities.Remove(obj);
        }
        public virtual T GetByID(object id)
        {
            return _entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            _entities.Add(entity);
        }
    }
}

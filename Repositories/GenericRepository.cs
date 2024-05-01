using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Repositories
{
    public class GenericRepository<T> where T:class
    {
        private InventoryApplicationContext _context;
        public GenericRepository(InventoryApplicationContext context)
        {
            _context = context;
        }
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            var x = _context.Set<T>();
            return x.ToList();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public IEnumerable<T> find(Expression<Func<T,bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
    }
}

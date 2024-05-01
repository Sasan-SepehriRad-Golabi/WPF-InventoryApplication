using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Repositories
{
    public class GenericAdminUserRepository<T> where T:class,new()
    {
        InventoryAdminContext _context { get; set; }
        public GenericAdminUserRepository(InventoryAdminContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<T> GetAll()
        {
            var x = _context.set<T>().SetOfOurType;
            return x;
        }
        public void Add(Models.AdminUser entity)
        {
            _context.set<T>().InsertAdmins(entity);
        }
        public IEnumerable<T> find(Func<T, bool> predicate)
        {
            AdminDbSet<T> test = _context.set<T>();
            return test.FindAdmins(predicate);
        }
    }
}

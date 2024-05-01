using InventoryApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.DataAccess
{
    public class AdminUnitofWork : IUnitOfWork
    {
        InventoryAdminContext _context;
        public GenericAdminUserRepository<Models.AdminUser> AdminRepos { get; set; }
        public AdminUnitofWork(InventoryAdminContext ctx)
        {
            _context = ctx;
            AdminRepos = new GenericAdminUserRepository<Models.AdminUser>(ctx);
        }
        public int complete()
        {
            return 0;
        }

        public void Dispose()
        {
          
        }
    }
}

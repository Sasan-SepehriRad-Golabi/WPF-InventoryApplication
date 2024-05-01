using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Repositories
{
    public class UserRepository<T> : GenericRepository<T> where T : class
    {
        public UserRepository(InventoryApplicationContext context) : base(context)
        {
        }
    }
}

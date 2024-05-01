using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Repositories
{
    public class LogRepository<T> : GenericRepository<T> where T : class
    {
        public LogRepository(InventoryApplicationContext context) : base(context)
        {
        }
    }
}

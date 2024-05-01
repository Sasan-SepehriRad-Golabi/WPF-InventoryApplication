using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace InventoryApplication.DataAccess
{
    public class InventoryApplicationContext:DbContext
    {
    
        public DbSet<Models.Inventory> Invetntories { get; set; }
        public DbSet<Models.Material> Materials { get; set; }
        public DbSet<Models.ProviderCompany> ProviderCompanies { get; set; }
        public DbSet<Models.Receipt> Receipts { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Log> Logs { get; set; }
        public DbSet<Models.Peronel> Personels { get; set; }
        public DbSet<Models.testtt> testtts { get; set; }
        public DbSet<Models.AdminUser> AdminUsers { get; set; }
        
    }
}

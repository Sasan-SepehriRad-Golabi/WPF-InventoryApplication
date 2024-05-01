using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.DataAccess
{
    public class UnitOfWork: IUnitOfWork 
    {
        private InventoryApplicationContext _MyContext;
        public Repositories.GenericRepository<Models.Inventory> MyInventoriesRep;
        public Repositories.GenericRepository<Models.Log> MyLogsRep;
        public Repositories.GenericRepository<Models.Material> MyMaterialsRep;
        public Repositories.GenericRepository<Models.ProviderCompany> MyProviderCompaniesRep;
        public Repositories.GenericRepository<Models.Receipt> MyReceiptsRep;
        public Repositories.GenericRepository<Models.User> MyUsersRep;
        public Repositories.GenericRepository<Models.testtt> MytestttRep;
        public Repositories.GenericRepository<Models.Peronel> MyPersonRep;
        public Repositories.GenericRepository<Models.AdminUser> MyAdminUsersRep;
        public UnitOfWork(InventoryApplicationContext context)
        {
            _MyContext = context;
            MyInventoriesRep = new Repositories.GenericRepository<Models.Inventory>(context);
            MyLogsRep = new Repositories.GenericRepository<Models.Log>(context);
            MyMaterialsRep = new Repositories.GenericRepository<Models.Material>(context);
            MyProviderCompaniesRep = new Repositories.GenericRepository<Models.ProviderCompany>(context);
            MyReceiptsRep = new Repositories.GenericRepository<Models.Receipt>(context);
            MyUsersRep = new Repositories.GenericRepository<Models.User>(context);
            MytestttRep = new Repositories.GenericRepository<Models.testtt>(context);
            MyPersonRep = new Repositories.GenericRepository<Models.Peronel>(context);
            MyAdminUsersRep = new Repositories.GenericRepository<Models.AdminUser>(context);
        }
        public int complete()
        {
             return _MyContext.SaveChanges();
        }

        public void Dispose()
        {
            _MyContext.Dispose();
        }
    }
}

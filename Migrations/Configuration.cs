namespace InventoryApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryApplication.DataAccess.InventoryApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryApplication.DataAccess.InventoryApplicationContext context)
        {
            context.Database.ExecuteSqlCommand("Truncate table AdminUsers");
            context.AdminUsers.AddOrUpdate(new Models.AdminUser()
            {
                UserName = "admin",
                Password = "admin",
                IsAdmin = true
            });
        }
    }
}

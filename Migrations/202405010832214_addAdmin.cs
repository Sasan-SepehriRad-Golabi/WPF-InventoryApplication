namespace InventoryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminUsers");
        }
    }
}

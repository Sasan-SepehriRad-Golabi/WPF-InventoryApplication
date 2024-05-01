namespace InventoryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProperInventory1 = c.Boolean(nullable: false),
                        ProperInventory2 = c.Boolean(nullable: false),
                        Location = c.String(),
                        Accessors = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        classofDevice = c.String(),
                        IsRead = c.String(),
                        TimeofLog = c.DateTime(nullable: false),
                        LogReport = c.String(),
                        UserInChargeofReading = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefId = c.Int(nullable: false),
                        Name = c.String(),
                        ProperMaterial1 = c.Boolean(nullable: false),
                        ProperMaterial2 = c.Boolean(nullable: false),
                        ProperMaterial3 = c.Boolean(nullable: false),
                        ProperMaterial4 = c.Boolean(nullable: false),
                        ProperMaterial5 = c.Boolean(nullable: false),
                        testProperMaterial = c.Boolean(nullable: false),
                        notifyuser = c.Boolean(nullable: false),
                        DateofEntrancetoStore = c.String(),
                        TimeofEntrancetoStore = c.String(),
                        DateofBuying = c.String(),
                        TimeofBuying = c.String(),
                        DateofExitofStore = c.String(),
                        TimeofExitofStore = c.String(),
                        IfUsed = c.Boolean(nullable: false),
                        MaterialGiverToUserSecondary = c.String(),
                        MaterialUser = c.String(),
                        MaterialUserRequestNumber = c.Int(nullable: false),
                        MaterialRequester = c.String(),
                        InstalledLocation = c.String(),
                        DateofDelivertoUser = c.String(),
                        RemainedNumber = c.Int(nullable: false),
                        MinimumAcceptableDevices = c.String(),
                        NumberofMaterial = c.String(),
                        PrivateNumberofMaterial = c.String(),
                        IsAccessory = c.Int(nullable: false),
                        ICTSection = c.Int(nullable: false),
                        MaterialImage = c.Binary(),
                        MaterialReceiptnumber = c.String(),
                        ICT_Tag = c.String(),
                        MaterialInventoryid = c.Int(nullable: false),
                        MaterialCompanyid = c.Int(nullable: false),
                        MaterialBarCode = c.String(),
                        MaterialGiverToUserMain = c.String(),
                        OtherDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Peronels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PersonelyNumber = c.String(),
                        Company = c.String(),
                        Department = c.String(),
                        DateOfGettingHired = c.String(),
                        TitleInReal = c.String(),
                        OtherPoints = c.String(),
                        PersonelImage = c.Binary(),
                        correctpersonelynumber = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProperProviderCompany0 = c.Boolean(nullable: false),
                        ProperProviderCompany1 = c.Boolean(nullable: false),
                        ProperProviderCompany2 = c.Boolean(nullable: false),
                        ProperProviderCompany3 = c.Boolean(nullable: false),
                        NameofCompany = c.String(),
                        LocationAddress = c.String(),
                        CallNumber = c.String(),
                        FaxNumber = c.String(),
                        Email = c.String(),
                        Evaluation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptNumber = c.String(),
                        ProperReceipt1 = c.Boolean(nullable: false),
                        ProperReceipt2 = c.Boolean(nullable: false),
                        ProperReceipt3 = c.Boolean(nullable: false),
                        ProperReceipt4 = c.Boolean(nullable: false),
                        ProperReceipt5 = c.Boolean(nullable: false),
                        CostValue = c.String(),
                        IsPayed = c.Int(nullable: false),
                        Issuer = c.String(),
                        TheProviderCompanyid = c.Int(nullable: false),
                        DateofIssue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.testtts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        User_Name = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Access_Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.testtts");
            DropTable("dbo.Receipts");
            DropTable("dbo.ProviderCompanies");
            DropTable("dbo.Peronels");
            DropTable("dbo.Materials");
            DropTable("dbo.Logs");
            DropTable("dbo.Inventories");
        }
    }
}

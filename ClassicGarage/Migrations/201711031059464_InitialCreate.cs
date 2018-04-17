namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnouncementsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Activ = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mark = c.String(maxLength: 50),
                        Model = c.String(maxLength: 50),
                        Year = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        VIN = c.String(maxLength: 17),
                        Photo = c.String(),
                        DateOfPurchase = c.DateTime(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        PurchasePrice = c.Single(nullable: false),
                        SalePrice = c.Single(nullable: false),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OwnerModels", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.OwnerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        PhoneNum = c.String(maxLength: 12),
                        Mail = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PartsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        CatalogNmuber = c.Int(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        PurchasePrice = c.Single(nullable: false),
                        SalePrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.RepairModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Desc = c.String(maxLength: 500),
                        PriceOfRepair = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnnouncementsModels", "CarID", "dbo.CarModels");
            DropForeignKey("dbo.RepairModels", "CarID", "dbo.CarModels");
            DropForeignKey("dbo.PartsModels", "CarID", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.RepairModels", new[] { "CarID" });
            DropIndex("dbo.PartsModels", new[] { "CarID" });
            DropIndex("dbo.CarModels", new[] { "OwnerID" });
            DropIndex("dbo.AnnouncementsModels", new[] { "CarID" });
            DropTable("dbo.RepairModels");
            DropTable("dbo.PartsModels");
            DropTable("dbo.OwnerModels");
            DropTable("dbo.CarModels");
            DropTable("dbo.AnnouncementsModels");
        }
    }
}

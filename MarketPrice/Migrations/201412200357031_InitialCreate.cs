namespace MarketPrice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commodities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        UnitOfSale = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(),
                        MarketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markets", t => t.MarketId, cascadeDelete: true)
                .Index(t => t.Username, unique: true)
                .Index(t => t.MarketId);
            
            CreateTable(
                "dbo.VendorCommodities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        CommodityId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commodities", t => t.CommodityId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.CommodityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorCommodities", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.VendorCommodities", "CommodityId", "dbo.Commodities");
            DropForeignKey("dbo.Vendors", "MarketId", "dbo.Markets");
            DropIndex("dbo.VendorCommodities", new[] { "CommodityId" });
            DropIndex("dbo.VendorCommodities", new[] { "VendorId" });
            DropIndex("dbo.Vendors", new[] { "MarketId" });
            DropIndex("dbo.Vendors", new[] { "Username" });
            DropTable("dbo.VendorCommodities");
            DropTable("dbo.Vendors");
            DropTable("dbo.Markets");
            DropTable("dbo.Commodities");
        }
    }
}

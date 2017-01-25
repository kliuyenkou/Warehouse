namespace Warehouse.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductInTheShops",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ShopId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 64),
                        Address = c.String(maxLength: 128),
                        Schedule = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInTheShops", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ProductInTheShops", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductInTheShops", new[] { "ShopId" });
            DropIndex("dbo.ProductInTheShops", new[] { "ProductId" });
            DropTable("dbo.Shops");
            DropTable("dbo.ProductInTheShops");
            DropTable("dbo.Products");
        }
    }
}

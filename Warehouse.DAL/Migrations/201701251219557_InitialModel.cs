using System.Data.Entity.Migrations;

namespace Warehouse.DAL.Migrations
{
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Products",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Title = c.String(false, 64),
                        Description = c.String(maxLength: 128)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.ProductInTheShops",
                    c => new
                    {
                        ProductId = c.Int(false),
                        ShopId = c.Int(false)
                    })
                .PrimaryKey(t => new {t.ProductId, t.ShopId})
                .ForeignKey("dbo.Products", t => t.ProductId, true)
                .ForeignKey("dbo.Shops", t => t.ShopId, true)
                .Index(t => t.ProductId)
                .Index(t => t.ShopId);

            CreateTable(
                    "dbo.Shops",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Title = c.String(false, 64),
                        Address = c.String(maxLength: 128),
                        Schedule = c.String(maxLength: 128)
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ProductInTheShops", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ProductInTheShops", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductInTheShops", new[] {"ShopId"});
            DropIndex("dbo.ProductInTheShops", new[] {"ProductId"});
            DropTable("dbo.Shops");
            DropTable("dbo.ProductInTheShops");
            DropTable("dbo.Products");
        }
    }
}
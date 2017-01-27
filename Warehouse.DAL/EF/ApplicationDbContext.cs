using System.Data.Entity;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Migrations;

namespace Warehouse.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ProductInTheShop> ProductsInTheShops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

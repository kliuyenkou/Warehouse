using System.Data.Entity;
using Warehouse.DAL.Entities;

namespace Warehouse.DAL.EF
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var shop1 = new Shop
            {
                Title = "Nike shop. Minsk",
                Address = "pr-t Pobediteley, 65, Minsk",
                Schedule = "Sun.-Mon.: 9 - 21"
            };
            var shop2 = new Shop
            {
                Title = "Nike store. London",
                Address = "14-16 Neal Street, London",
                Schedule = "Sun.-Mon.: 10 - 20"
            };
            var shop3 = new Shop
            {
                Title = "Nike Town",
                Address = "6 E 57th St, New York",
                Schedule = "Sun.-Mon.: 10 - 20"
            };
            context.Shops.Add(shop1);
            context.Shops.Add(shop2);
            context.Shops.Add(shop3);

            var product1 = new Product { Title = "Nike AeroSwift", Description = "Running shorts" };
            var product2 = new Product { Title = "Nike Dry Miler", Description = "Running top" };
            var product3 = new Product { Title = "Nike Rafael Nadal headband", Description = "Tennis headband" };
            var product4 = new Product { Title = "NikeCourt Rafael Nadal", Description = "T-shirt" };
            var product5 = new Product { Title = "NikeCourt Roger Federer", Description = "T-shirt" };
            var product6 = new Product { Title = "NikeCourt AeroBill Roger Federer", Description = "Adjustable hat" };
            var product7 = new Product { Title = "Nike Tiempo", Description = "Football boots" };
            var product8 = new Product { Title = "Nike Mercurial IC", Description = "Indoor football shoe" };
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            context.Products.Add(product5);
            context.Products.Add(product6);
            context.Products.Add(product7);
            context.Products.Add(product8);

            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop1, Product = product1 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop1, Product = product2 });

            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop2, Product = product1 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop2, Product = product2 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop2, Product = product3 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop2, Product = product4 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop2, Product = product5 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop2, Product = product6 });

            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop3, Product = product3 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop3, Product = product4 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop3, Product = product5 });
            context.ProductsInTheShops.Add(new ProductInTheShop { Shop = shop3, Product = product6 });

            base.Seed(context);
        }
    }
}
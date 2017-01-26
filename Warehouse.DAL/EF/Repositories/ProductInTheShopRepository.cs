using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Interfaces.Repositories;

namespace Warehouse.DAL.EF.Repositories
{
    public class ProductInTheShopRepository : BaseRepository<ProductInTheShop>, IProductInTheShopRepository
    {
        public ProductInTheShopRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ProductInTheShop Get(int productId, int shopId)
        {
            return context.ProductsInTheShops.Find(productId, shopId);
        }

        public IEnumerable<ProductInTheShop> GetRecordsWithProductLoaded(Expression<Func<ProductInTheShop, bool>> predicate)
        {
            return context.ProductsInTheShops.Where(predicate).Include(r => r.Product).ToList();
        }
    }
}

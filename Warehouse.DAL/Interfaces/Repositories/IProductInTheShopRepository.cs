using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Interfaces.Repositories
{
    public interface IProductInTheShopRepository : IRepository<ProductInTheShop>
    {
        ProductInTheShop Get(int productId, int shopId);
        IEnumerable<ProductInTheShop> GetRecordsWithProductLoaded(Expression<Func<ProductInTheShop, bool>> predicate);
    }
}

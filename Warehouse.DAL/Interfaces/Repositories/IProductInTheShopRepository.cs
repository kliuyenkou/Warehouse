using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Interfaces.Repositories
{
    interface IProductInTheShopRepository : IRepository<ProductInTheShop>
    {
        ProductInTheShop Get(int productId, int shopId);
    }
}

using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Interfaces.Repositories
{
    public interface IProductInTheShopRepository : IRepository<ProductInTheShop>
    {
        ProductInTheShop Get(int productId, int shopId);
    }
}

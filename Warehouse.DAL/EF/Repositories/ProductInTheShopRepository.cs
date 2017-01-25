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
    }
}

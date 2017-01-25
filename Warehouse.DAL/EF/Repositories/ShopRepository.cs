using Warehouse.DAL.Entities;
using Warehouse.DAL.Interfaces.Repositories;

namespace Warehouse.DAL.EF.Repositories
{
    class ShopRepository : BaseRepository<Shop>, IShopRepository
    {
        public ShopRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Shop GetById(int shopId)
        {
            return context.Shops.Find(shopId);
        }
    }
}

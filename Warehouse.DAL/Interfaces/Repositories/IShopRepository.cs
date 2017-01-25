using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Interfaces.Repositories
{
    interface IShopRepository : IRepository<Shop>
    {
        Shop GetById(int shopId);
    }
}

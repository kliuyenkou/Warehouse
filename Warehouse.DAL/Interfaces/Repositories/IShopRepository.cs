using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Interfaces.Repositories
{
    public interface IShopRepository : IRepository<Shop>
    {
        Shop GetById(int shopId);
    }
}

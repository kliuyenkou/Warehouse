using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Interfaces.Repositories
{
    interface IProductRepository : IRepository<Product>
    {
        Product GetById(int productId);
    }
}

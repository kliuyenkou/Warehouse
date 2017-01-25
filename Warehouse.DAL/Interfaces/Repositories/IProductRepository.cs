using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetById(int productId);
    }
}

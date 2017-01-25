using Warehouse.DAL.Entities;
using Warehouse.DAL.Interfaces.Repositories;

namespace Warehouse.DAL.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Product GetById(int productId)
        {
            return context.Products.Find(productId);
        }
    }
}

using System.Threading.Tasks;
using Warehouse.DAL.EF.Repositories;
using Warehouse.DAL.Interfaces;
using Warehouse.DAL.Interfaces.Repositories;

namespace Warehouse.DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Shops = new ShopRepository(_context);
            ProductsInTheShops = new ProductInTheShopRepository(_context);
        }
        public IProductRepository Products { get; }
        public IShopRepository Shops { get; }
        public IProductInTheShopRepository ProductsInTheShops { get; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

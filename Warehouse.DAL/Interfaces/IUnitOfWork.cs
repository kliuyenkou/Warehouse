using System.Threading.Tasks;
using Warehouse.DAL.Interfaces.Repositories;

namespace Warehouse.DAL.Interfaces
{
    interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IShopRepository Shops { get; }
        IProductInTheShopRepository ProductsInTheShops { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

using System.Collections.Generic;
using System.Linq;
using Warehouse.BLL.Interfaces;
using Warehouse.BLL.Models;
using Warehouse.DAL.Management.Interfaces;

namespace Warehouse.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly ISupplyManagement _supplyManagement;
        public ProductService(ISupplyManagement supplyManagement)
        {
            _supplyManagement = supplyManagement;
        }
        public IEnumerable<Product> ProductsInShop(int shopId)
        {
            var products = _supplyManagement.GetProductsInShop(shopId);
            return products.Where(p => p != null).Select(p => new Product()
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description
            });
        }

    }
}

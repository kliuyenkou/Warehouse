using System.Collections.Generic;
using Warehouse.BLL.Models;

namespace Warehouse.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> ProductsInShop(int shopId);
        IEnumerable<Product> AllProducts();
        void SaveProduct(Product product);
    }
}

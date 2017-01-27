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
            return ConvertNotNullProductEntityToProduct(products);
        }

        public IEnumerable<Product> AllProducts()
        {
            var products = _supplyManagement.GetAllProducts();
            return ConvertNotNullProductEntityToProduct(products);
        }

        public void SaveProduct(Product product)
        {
            var productEntity = new DAL.Entities.Product
            {
                Title = product.Title,
                Description = product.Description
            };
            _supplyManagement.CreateProduct(productEntity);
        }

        public IEnumerable<Product> ProductsNotInShop(int shopId)
        {
            var products = _supplyManagement.GetProductsNotInShop(shopId);
            return ConvertNotNullProductEntityToProduct(products);
        }

        public void AddProductToTheShop(int shopId, int productId)
        {
            _supplyManagement.AddProductToTheShopById(shopId, productId);
        }

        public Product GetProduct(int productId)
        {
            var productEntity = _supplyManagement.GetProductById(productId);
            return new Product
            {
                Id = productEntity.Id,
                Title = productEntity.Title,
                Description = productEntity.Description
            };
        }

        private IEnumerable<Product> ConvertNotNullProductEntityToProduct(
            IEnumerable<DAL.Entities.Product> productsEntity)
        {
            return productsEntity.Where(p => p != null).Select(p => new Product
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description
            });
        }
    }
}
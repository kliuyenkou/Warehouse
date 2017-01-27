using System.Collections.Generic;
using System.Linq;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Interfaces;
using Warehouse.DAL.Management.Interfaces;

namespace Warehouse.DAL.Management
{
    public class SupplyManagement : ISupplyManagement
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplyManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Shop> GetShops()
        {
            return _unitOfWork.Shops.GetAll();
        }

        public IEnumerable<Product> GetProductsInShop(int shopId)
        {
            var products =
                _unitOfWork.ProductsInTheShops.GetRecordsWithProductLoaded(r => r.ShopId == shopId)
                    .Select(r => r.Product)
                    .ToList();
            return products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.Products.GetAll();
        }

        public void CreateProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Product> GetProductsNotInShop(int shopId)
        {
            var productsInTheShop =
                _unitOfWork.ProductsInTheShops.GetRecordsWithProductLoaded(r => r.ShopId == shopId)
                    .Select(r => r.Product)
                    .ToList();
            var allProducts = _unitOfWork.Products.GetAll();
            var productsNotInTheShop = allProducts.Where(p => !productsInTheShop.Any(p2 => p2.Id == p.Id));
            return productsNotInTheShop;
        }

        public void AddProductToTheShopById(int shopId, int productId)
        {
            var productInTheShop = new ProductInTheShop { ShopId = shopId, ProductId = productId };
            _unitOfWork.ProductsInTheShops.Add(productInTheShop);
            _unitOfWork.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _unitOfWork.Products.GetById(productId);
        }
    }
}
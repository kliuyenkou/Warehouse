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
            var products = _unitOfWork.ProductsInTheShops.GetRecordsWithProductLoaded(r => r.ShopId == shopId).Select(r => r.Product).ToList();
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
    }
}

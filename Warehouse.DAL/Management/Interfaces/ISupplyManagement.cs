﻿using System.Collections.Generic;
using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Management.Interfaces
{
    public interface ISupplyManagement
    {
        IEnumerable<Shop> GetShops();
        IEnumerable<Product> GetProductsInShop(int shopId);
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(Product product);
    }
}

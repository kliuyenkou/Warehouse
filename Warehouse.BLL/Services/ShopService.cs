using System.Collections.Generic;
using System.Linq;
using Warehouse.BLL.Interfaces;
using Warehouse.BLL.Models;
using Warehouse.DAL.Management.Interfaces;

namespace Warehouse.BLL.Services
{
    public class ShopService : IShopService
    {
        private readonly ISupplyManagement _supplyManagement;
        public ShopService(ISupplyManagement supplyManagement)
        {
            _supplyManagement = supplyManagement;
        }
        public IEnumerable<Shop> GetAllShops()
        {
            var shopsEntity = _supplyManagement.GetShops();
            var shopsModels =
                shopsEntity.Select(
                    sh => new Shop()
                    {
                        Id = sh.Id,
                        Title = sh.Title,
                        Address = sh.Address,
                        Schedule = sh.Schedule
                    });
            return shopsModels;
        }
    }
}

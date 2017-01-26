using System.Collections.Generic;
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
    }
}

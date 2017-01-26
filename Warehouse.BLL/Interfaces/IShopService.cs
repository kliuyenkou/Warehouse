using System.Collections.Generic;
using Warehouse.BLL.Models;

namespace Warehouse.BLL.Interfaces
{
    public interface IShopService
    {
        IEnumerable<Shop> GetAllShops();

    }
}

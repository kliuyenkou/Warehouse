using System.Linq;
using System.Web.Mvc;
using Warehouse.BLL.Interfaces;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;

        public HomeController(IShopService shopService, IProductService productService)
        {
            _shopService = shopService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            var allShops = _shopService.GetAllShops();
            var shopsViewModel = allShops.Select(
                sh => new ShopViewModel
                {
                    Id = sh.Id,
                    Title = sh.Title,
                    Address = sh.Address,
                    Schedule = sh.Schedule
                });
            return View(shopsViewModel);
        }
    }
}
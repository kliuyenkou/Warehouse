using System.Linq;
using System.Web.Mvc;
using Warehouse.BLL.Interfaces;
using Warehouse.BLL.Models;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Controllers
{
    public class StockController : Controller
    {
        private readonly IProductService _productService;

        public StockController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Products()
        {
            var products = _productService.AllProducts();
            var productsViewModel = products.Select(p =>
                new ProductViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description
                });
            return View("Products", productsViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var productViewModel = new ProductViewModel();
            ViewBag.Action = "Create";
            return View("ProductForm", productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("ProductForm", viewModel);
            var product = new Product()
            {
                Title = viewModel.Title,
                Description = viewModel.Description
            };
            _productService.SaveProduct(product);

            return RedirectToAction("Products");
        }
    }
}
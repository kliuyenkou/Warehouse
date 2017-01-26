using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Warehouse.BLL.Interfaces;
using Warehouse.Web.Dto;

namespace Warehouse.Web.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("shop/{shopId}/products")]
        public IEnumerable<ProductDto> GetProductsInTheShop(int shopId)
        {
            var products = _productService.ProductsInShop(shopId);
            var productsDto = products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description
            });
            return productsDto;
        }
    }
}

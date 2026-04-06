using Catalog.Application.Features.Brands.CreateBrand;
using Catalog.Application.Features.Brands.GetBrand;
using Catalog.Application.Features.Categories.CreateCategory;
using Catalog.Application.Features.Categories.GetCategory;
using Catalog.Application.Features.Products.CreateProducts;
using Catalog.Application.Features.Products.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CreateCategoryHandler _createCategoryHandler;
        private readonly GetCategoryHandler _getCategoryHandler;
        private readonly CreateBrandHandler _createBrandHandler;
        private readonly GetBrandHandler _getBrandHandler;
        private readonly CreateProductHandler _createProductHandler;
        private readonly GetProductHandler _getProductHandler;

        public CatalogController(
            CreateCategoryHandler createCategoryHandler, 
            GetCategoryHandler getCategoryHandler,
            CreateBrandHandler createBrandHandler, 
            GetBrandHandler getBrandHandler,
            CreateProductHandler createProductHandler, 
            GetProductHandler getProductHandler)
        {
            _createCategoryHandler = createCategoryHandler;
            _getCategoryHandler = getCategoryHandler;
            _createBrandHandler = createBrandHandler;
            _getBrandHandler = getBrandHandler;
            _createProductHandler = createProductHandler;
            _getProductHandler = getProductHandler; 
        }

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand cmd)
        {
            var result = await _createCategoryHandler.Handle(cmd);
            return Ok(result);
        }

        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await _getCategoryHandler.Handle(new GetCategoryQuery(id));
            return Ok(result);
        }


        [HttpPost("brands")]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand cmd)
        {
            var result = await _createBrandHandler.Handle(cmd);
            return Ok(result);
        }

        [HttpGet("brands/{id}")]
        public async Task<IActionResult> GetBrand(Guid id)
        {
            var result = await _getBrandHandler.Handle(new GetBrandQuery(id));
            return Ok(result);
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand cmd)
        {
            var result = await _createProductHandler.Handle(cmd);
            return Ok(result);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _getProductHandler.Handle(new GetProductQuery(id));
            return Ok(result);
        }
    }
}

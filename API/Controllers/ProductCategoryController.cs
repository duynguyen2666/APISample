using API.Database;
using API.Services.Abstractions;
using API.DTOs.Request;
using API.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var products = await _productCategoryService.GetAllWithAssociateDataAsync();
            return Ok(ConvertFromProductCategory(products));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProductCategory([FromBody] CreateProductCategoryReq createProductCategoryReq)
        {
            var category = ConvertFromCreateProductCategoryRequest(createProductCategoryReq);

            if (category == null)
            {
                return BadRequest();
            }
            if (await _productCategoryService.AddAsync(category))
            {
                return Ok();
            }
            return BadRequest();
        }


        private ProductCategory? ConvertFromCreateProductCategoryRequest(CreateProductCategoryReq createProductCategoryReq)
        {
            if(createProductCategoryReq?.Name == null)
            {
                return null;
            }
            return new ProductCategory
            {
                Name = createProductCategoryReq.Name
            };
        }
        private List<ProductCategoryWithAssociateProductsDetailsResp> ConvertFromProductCategory(List<ProductCategory> productCategories)
        {
            if(productCategories == null || !productCategories.Any())
            {
                return new List<ProductCategoryWithAssociateProductsDetailsResp>();
            }
            return productCategories.Select(category => new ProductCategoryWithAssociateProductsDetailsResp(category)).ToList();
        }
    }
}

using API.Database;
using API.Services.Abstractions;
using API.DTOs.Request;
using API.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(Convert(products));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductReq createProductRequest)
        {
            var product = ConvertFromCreateProductRequest(createProductRequest);
            if (product == null)
            {
                return BadRequest();
            }
            await _productService.AddAsync(product);
            return Ok();
        }


        private Product? ConvertFromCreateProductRequest(CreateProductReq createProductRequest)
        {
            if (createProductRequest == null ||
                createProductRequest.CategoryId == null ||
                createProductRequest.Name == null ||
                createProductRequest.Price == null ||
                createProductRequest.Quantity == null)
            {
                return default;
            }

            return new Product()
            {
                Name = createProductRequest.Name,
                CategoryId = createProductRequest.CategoryId.Value,
                Price = createProductRequest.Price.Value,
                Quantity = createProductRequest.Quantity.Value
            };
        }
        private List<ProductDetailsResp> Convert(List<Product> productEntities)
        {
            if(productEntities == null || !productEntities.Any())
            {
                return new List<ProductDetailsResp>();
            }
            return productEntities.Select(entity => new ProductDetailsResp(entity)).ToList();
        }
    }
}

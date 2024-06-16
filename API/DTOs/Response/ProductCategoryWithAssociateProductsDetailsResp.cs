using API.Database;
using Newtonsoft.Json;

namespace API.DTOs.Response
{
    public class ProductCategoryWithAssociateProductsDetailsResp
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("products")]
        public List<ProductDetailsResp> Products { get; set; }

        public ProductCategoryWithAssociateProductsDetailsResp(ProductCategory productCategory)
        {
            Id = productCategory.Id;
            Name = productCategory.Name;
            Products = productCategory.Products.Select(product => new ProductDetailsResp(product)).ToList();
        }
    }
}

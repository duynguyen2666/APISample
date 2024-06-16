using API.Database;
using Newtonsoft.Json;

namespace API.DTOs.Response
{
    public class ProductDetailsResp
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }

        public ProductDetailsResp(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
            Category = product.Category.Name;
        }
    }
}

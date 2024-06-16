using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Request
{
    public class CreateProductReq
    {
        [JsonProperty("name")]
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string? Name { get; set; }

        [JsonProperty("price")]
        [Required]
        [Range(1, int.MaxValue)]
        public int? Price { get; set; }

        [JsonProperty("quantity")]
        [Required]
        [Range(1, int.MaxValue)]
        public int? Quantity { get; set; }

        [JsonProperty("category_id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int? CategoryId { get; set; }
    }
}

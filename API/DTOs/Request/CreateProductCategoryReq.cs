using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Request
{
    public class CreateProductCategoryReq
    {
        [JsonProperty("name")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}

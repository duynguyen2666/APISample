using Newtonsoft.Json;

namespace API.DTOs.Response
{
    public class CategoryDetailsResp
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

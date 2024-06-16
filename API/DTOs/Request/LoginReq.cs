using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Request
{
    public class LoginReq
    {
        [Required(AllowEmptyStrings = false)]
        [JsonProperty("username")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}

using Newtonsoft.Json;

namespace API.DTOs.Response
{
    public class LoginResp
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

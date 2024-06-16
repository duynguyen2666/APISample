using API.DTOs.Request;
using API.DTOs.Response;
using API.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginReq loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest?.Username) || string.IsNullOrEmpty(loginRequest?.Password))
            {
                return BadRequest();
            }

            var token = await _userService.LoginAsync(loginRequest.Username, loginRequest.Password);
            if(string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            return Ok(new LoginResp
            {
                Token = token
            });
        }
    }
}

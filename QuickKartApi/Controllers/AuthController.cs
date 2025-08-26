using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickKartApi.DTO_s;
using QuickKartApi.Services;

namespace QuickKartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var token= await _userService.RegisterAsync(registerDto);
            if (token == null) BadRequest();
            return Ok(new {Token=token});
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            if (token == null) BadRequest();
            return Ok(new { Token = token });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Society.Application.Interfaces.Services;
using Society.Application.DTOs;
using Society.Application.DTOs.Auth;

namespace Society.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            try
            {
                await _authService.RegisterAsync(dto);
                return Ok(new { message = "user registered successfully!" });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    } 
}

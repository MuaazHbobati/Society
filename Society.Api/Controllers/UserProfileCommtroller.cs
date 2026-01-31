using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Society.Application.Interfaces.Services;
using Society.Application.DTOs;
using Society.Application.DTOs.Auth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Society.Application.DTOs.UserProfile;

namespace Society.Api.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Authorize]
    public class UserProfileCommtroller : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileCommtroller(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            await _userProfileService.UpdateMyUserProfileAsync(Guid .Parse(userId), dto);
            return Ok(new { message = " Prfile updated successfully"});
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }


            var profile = await _userProfileService.GetMyProfileAsync(Guid .Parse(userId));
            if (profile == null)
            {
                NotFound();
            }

            return Ok(profile);
       
        }
        [Authorize]
        [HttpGet("test-auth")]
        public IActionResult TestAuth()
        {
            return Ok(new
            {
                User.Identity?.IsAuthenticated,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }
    }
}

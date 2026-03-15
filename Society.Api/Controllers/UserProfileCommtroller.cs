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

            await _userProfileService.UpdateMyUserProfileAsync(int .Parse(userId), dto);
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


            var profile = await _userProfileService.GetMyProfileAsync(int .Parse(userId));
            if (profile == null)
            {
                return NotFound();
            }


            return Ok(profile);
       
        }


    }
}

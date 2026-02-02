using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Society.Application.Interfaces.Services;
using Society.Application.DTOs.PartnerSystem;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Society.Application.Services;

namespace Society.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // لازم المستخدم يكون مسجل دخول
    public class PartnerRequestController : ControllerBase
    {
        private readonly IPartnerRequestService _service;

        public PartnerRequestController(IPartnerRequestService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePartnerRequestDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized();

            var creatorId = Guid.Parse(userIdClaim);

            var id = await _service.CreateAsync(creatorId, dto);
            return Ok(new { id, message = "Partner request created successfully!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Society.Application.DTOs.TeamSystem.TeamFormation;
using Society.Application.Interfaces.Services.TeamSystem.TeamFormation;

namespace Society.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // لازم تسجيل دخول لكل الأفعال هنا
    public class TeamFormationController : ControllerBase
    {
        private readonly ITeamFormationService _service;

        public TeamFormationController(ITeamFormationService service)
        {
            _service = service;
        }

        // GET: api/TeamFormation
        [HttpGet]
        public async Task<ActionResult<List<TeamFormationListDto>>> GetAll()
        {
            var formations = await _service.GetAllAsync();
            return Ok(formations);
        }

        // GET: api/TeamFormation/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamFormationDetailsDto>> GetById(Guid id)
        {
            try
            {
                var formation = await _service.GetByIdAsync(id);
                return Ok(formation);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/TeamFormation
        [HttpPost]
        public async Task<ActionResult<TeamFormationDetailsDto>> Create([FromBody] CreateTeamFormationDto dto)
        {
            // 🔹 نجيب الـ creatorId من الـ JWT Token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "User not found in token" });
            }

            Guid creatorId = Guid.Parse(userIdClaim);

            var formation = await _service.CreateAsync(dto, creatorId);

            // نرجع CreatedAtAction مع الـ id الجديد
            return CreatedAtAction(nameof(GetById), new { id = formation.Id }, formation);
        }
    }
}

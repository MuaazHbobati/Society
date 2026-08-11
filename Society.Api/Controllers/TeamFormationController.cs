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
    [Authorize]
    public class TeamFormationController : ControllerBase
    {
        private readonly ITeamFormationService _service;

        public TeamFormationController(ITeamFormationService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<TeamFormationListDto>>> GetAll()
        {
            var formations = await _service.GetAllAsync();
            return Ok(formations);
        }

        [HttpGet]
        public async Task<ActionResult<FormationResponseDto>> GetFormations([FromQuery] FormationRequestDto request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "User not found in token" });
            }
            int userId = int.Parse(userIdClaim);

            var result = await _service.GetFormationsAsync(userId, request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamFormationDetailsDto>> GetById(int id)
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

        [HttpPost]
        public async Task<ActionResult<TeamFormationDetailsDto>> Create([FromBody] CreateTeamFormationDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "User not found in token" });
            }
            int creatorId = int.Parse(userIdClaim);
            var formation = await _service.CreateAsync(dto, creatorId);
            return CreatedAtAction(nameof(GetById), new { id = formation.Id }, formation);
        }

    }
}


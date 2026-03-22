using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Society.Application.DTOs.TeamSystem.TeamFormation;
using Society.Application.Interfaces.Services;
using Society.Application.DTOs;
using Society.Application.DTOs.Program;
using Society.Application.DTOs.Subject;
using System.Security.Claims;
namespace Society.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProgramController : ControllerBase
    { 
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet("programs")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ProgramDto>>> GetAllPrograms()
        {
            try 
            {
                return Ok(await _programService.GetAllProgramsAsync()); 
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, new { message = "خطأ في جلب البرامج", error = ex.Message }); 
            }
        }

        [HttpGet("subjects/{programId}")]
        public async Task<ActionResult<List<SubjectDto>>> GetSubjectsByProgramId(int programId)
        {
            try
            {
                return Ok(await _programService.GetSubjectsByProgramIdAsync(programId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "خطأ في جلب المواد", error = ex.Message });
            }
        }

        [HttpGet("my-subjects")]
        public async Task<ActionResult<List<SubjectDto>>> GetMySubjects()
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "المستخدم غير مصرح له" });
                }

                var subjects = await _programService.GetMySubjectsAsync(userId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "خطأ في جلب المواد", error = ex.Message });
            }
        }
    }
}

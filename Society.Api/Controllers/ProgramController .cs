using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Society.Application.DTOs.TeamSystem.TeamFormation;
using Society.Application.Interfaces.Services;
using Society.Application.DTOs;
using Society.Application.DTOs.Program;
using Society.Application.DTOs.Subject;
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
    }
}

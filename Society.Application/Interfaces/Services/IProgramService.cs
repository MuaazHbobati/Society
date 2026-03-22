using Society.Application.DTOs.Program;
using Society.Application.DTOs.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Interfaces.Services
{    
    public interface IProgramService
    {
        Task<List<ProgramDto>> GetAllProgramsAsync();            
        Task<List<SubjectDto>> GetSubjectsByProgramIdAsync(int programId);
        Task<ProgramDto?> GetProgramByIdAsync(int programId);
        Task<List<SubjectDto>> GetMySubjectsAsync(int userId);
    }
}

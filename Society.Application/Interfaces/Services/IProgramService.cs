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

        // جلب المواد حسب معرف البرنامج
        Task<List<SubjectDto>> GetSubjectsByProgramIdAsync(int programId);
    }
}

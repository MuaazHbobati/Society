using Society.Application.DTOs.Program;
using Society.Application.DTOs.Subject;
using Society.Application.Interfaces.Repositories;
using Society.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Society.Application.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<List<ProgramDto>> GetAllProgramsAsync()
        {
            var programs = await _programRepository.GetAllProgramsAsync();
            return programs.Select(p => new ProgramDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

        }

        public async Task<List<SubjectDto>> GetSubjectsByProgramIdAsync(int programId)
        {
            var subjects = await _programRepository.GetSubjectsByProgramIdAsync(programId);
            return subjects.Select(s => new SubjectDto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }
    }
}

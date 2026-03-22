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
        private readonly IUserRepository _userRepository;

        public ProgramService(IProgramRepository programRepository, IUserRepository userRepository)
        {
            _programRepository = programRepository;
            _userRepository = userRepository;
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

        public async Task<List<SubjectDto>> GetMySubjectsAsync(int userId)
        {
            var user = await _userRepository.GetUserWithProfileAsync(userId);
            if (user == null)
            {
                throw new Exception("المستخدم غير موجود");
            }

            var subjects = await _programRepository.GetSubjectsByProgramIdAsync(user.ProgramId);
            return subjects.Select(s => new SubjectDto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }

        public async Task<ProgramDto?> GetProgramByIdAsync(int programId)
        {
            var program = await _programRepository.GetProgramByIdAsync(programId);
            if (program == null) return null;

            return new ProgramDto
            {
                Id = program.Id,
                Name = program.Name
            };
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

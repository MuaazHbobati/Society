using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Application.DTOs.TeamSystem.TeamFormation;
using Society.Application.Interfaces.Repositories.TeamSystem;
using Society.Application.Interfaces.Services.TeamSystem.TeamFormation;
using Society.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace Society.Application.Services.TeamSystem.TeamFormation
{
    public class TeamFormationService : ITeamFormationService
    {
        private readonly ITeamFormationRepository _repository;

        public TeamFormationService(ITeamFormationRepository repository)
        {
            _repository = repository;
        }

        public async Task<TeamFormationDetailsDto> CreateAsync(CreateTeamFormationDto dto, int creatorId)
        {

            var programSubjectId = await _repository.GetProgramSubjectIdAsync(dto.ProgramId, dto.SubjectId);

            if (programSubjectId == null)
            {
                throw new Exception("البرنامج والمادة غير متوافقين");
            }


            var formation = new Society.Domain.Entities.TeamFormation
            {
                CreatorId = creatorId,
                ProgramSubjectId = programSubjectId.Value,  
                Title = dto.Title,
                Description = dto.Description,
                ClassName = dto.ClassName,
                MaxMembers = dto.MaxMembers,
                CreatedAt = DateTime.UtcNow,
                Status = Domain.Enums.TeamFormationStatus.Open,
                CurrentMembersCount = 1
            };

            await _repository.AddAsync(formation);
            await _repository.SaveChangesAsync();

            var createdFormation = await _repository.GetByIdAsync(formation.Id);

            return MapToDetailsDto(createdFormation);
        }

        public async Task<List<TeamFormationListDto>> GetAllAsync()
        {
            var formations = await _repository.GetAllAsync();

            return formations.Select(f => new TeamFormationListDto
            {
                Id = f.Id,
                CreatorId = f.CreatorId,
                Title = f.Title,
                Description = f.Description,
                ClassName = f.ClassName,
                ProgramName = f.ProgramSubject.Program.Name,
                SubjectName = f.ProgramSubject.Subject.Name,
                MaxMembers = f.MaxMembers,
                CurrentMembersCount = f.CurrentMembersCount,
                Status = f.Status
            }).ToList();
        }

        public async Task<TeamFormationDetailsDto> GetByIdAsync(int id)
        {
            var formation = await _repository.GetByIdAsync(id);

            if (formation == null)
                throw new Exception("Team formation not found");

            return MapToDetailsDto(formation);
        }


        private TeamFormationDetailsDto MapToDetailsDto(Society.Domain.Entities.TeamFormation formation)
        {
            return new TeamFormationDetailsDto
            {
                Id = formation.Id,
                Title = formation.Title,
                Description = formation.Description,
                ClassName = formation.ClassName,
                ProgramName = formation.ProgramSubject.Program.Name,
                SubjectName = formation.ProgramSubject.Subject.Name,
                MaxMembers = formation.MaxMembers,
                CurrentMembersCount = formation.CurrentMembersCount,
                Status = formation.Status
            };
        }

    }
}

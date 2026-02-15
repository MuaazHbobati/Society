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

        public async Task<TeamFormationDetailsDto> CreateAsync(CreateTeamFormationDto dto, Guid creatorId)
        {
            var formation = new Society.Domain.Entities.TeamFormation
            {
                Id = Guid.NewGuid(),
                CreatorId = creatorId,
                ProgramSubjectId = dto.SubjectId,
                Title = dto.Title,
                Description = dto.Description,
                MaxMembers = dto.MaxMembers,
                CreatedAt = DateTime.UtcNow,
                Status = Domain.Enums.TeamFormationStatus.Open,
                CurrentMembersCount = 1

            };

            await _repository.AddAsync(formation);
            await _repository.SaveChangesAsync();

            return MapToDetailsDto(formation);
        }

        public async Task<List<TeamFormationListDto>> GetAllAsync()
        {
            var formations = await _repository.GetAllAsync();

            return formations.Select(f => new TeamFormationListDto
            {
                Id = f.Id,
                Title = f.Title,
                ProgramName = f.ProgramSubject.Program.Name,
                SubjectName = f.ProgramSubject.Subject.Name,
                MaxMembers = f.MaxMembers,
                CurrentMembersCount = f.CurrentMembersCount,
                Status = f.Status
            }).ToList();
        }

        public async Task<TeamFormationDetailsDto> GetByIdAsync(Guid id)
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
                ProgramName = "اسم البرنامج لاحقاً من ProgramSubject/Program",
                SubjectName = "اسم المادة لاحقاً من ProgramSubject/Subject",
                MaxMembers = formation.MaxMembers,
                CurrentMembersCount = formation.CurrentMembersCount,
                Status = formation.Status
            };
        }

    }
}

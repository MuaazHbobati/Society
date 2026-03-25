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
using Society.Application.Interfaces.Repositories;


namespace Society.Application.Services.TeamSystem.TeamFormation
{
    public class TeamFormationService : ITeamFormationService
    {
        private readonly ITeamFormationRepository _repository;
        private readonly IUserRepository _userRepository;

        public TeamFormationService(ITeamFormationRepository repository,IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<TeamFormationDetailsDto> CreateAsync(CreateTeamFormationDto dto, int creatorId)
        {
            var user = await _userRepository.GetUserWithProfileAsync(creatorId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var programSubjectId = await _repository.GetProgramSubjectIdAsync(user.ProgramId, dto.SubjectId);

            if (programSubjectId == null)
            {
                throw new Exception("المادة غير متوافقة مع برنامجك");
            }

            var formation = new Society.Domain.Entities.TeamFormation
            {
                CreatorId = creatorId,
                ProgramSubjectId = programSubjectId.Value,
                TutorName = dto.TutorName,
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
                CreatorName = f.Creator.Person.FirstName + " " + f.Creator.Person.LastName,
                CreatorUsername = f.Creator.Username,
                CreatorPhoto = f.Creator.Profile.ProfilePictureUrl,
                TutorName = f.TutorName,
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

        public async Task<FormationResponseDto>GetFormationsAsync(int userId, FormationRequestDto formationRequest)
        {
            var user = await _userRepository.GetUserWithProfileAsync(userId);
            var formations = await _repository.GetFormationsAsync(formationRequest, user.ProgramId);
            
            if (formations.Items.Count == 0)
            {
                return new FormationResponseDto
                {
                    Items = new List<TeamFormationListDto>(),
                    HasMore = false
                };

            }
            var formationList = formations.Items.Select(f=> new TeamFormationListDto
            {
                Id = f.Id,
                CreatorName = f.Creator.Person.FirstName + " " + f.Creator.Person.LastName,
                CreatorUsername = f.Creator.Username,
                CreatorPhoto = f.Creator.Profile.ProfilePictureUrl,
                TutorName = f.TutorName,
                Description = f.Description,
                ClassName = f.ClassName,
                ProgramName = f.ProgramSubject.Program.Name,
                SubjectName = f.ProgramSubject.Subject.Name,
                MaxMembers = f.MaxMembers,
                CurrentMembersCount = f.CurrentMembersCount,
                Status = f.Status
            }).ToList();

            return new FormationResponseDto
            {
                Items = formationList,
                HasMore = formations.HasMore
            };
        }

        private TeamFormationDetailsDto MapToDetailsDto(Society.Domain.Entities.TeamFormation formation)
        {
            return new TeamFormationDetailsDto
            {
                Id = formation.Id,
                CreatorName = formation.Creator.Person.FirstName + " " + formation.Creator.Person.LastName,
                CreatorUsername = formation.Creator.Username,
                CreatorPhoto = formation.Creator.Profile.ProfilePictureUrl,
                TutorName = formation.TutorName,
                Description = formation.Description,
                ClassName = formation.ClassName,
                ProgramName = formation.ProgramSubject.Program.Name,
                SubjectName = formation.ProgramSubject.Subject.Name,
                MaxMembers = formation.MaxMembers,
                CurrentMembersCount = formation.CurrentMembersCount,               
                Status = formation.Status,
                CreatorSVUMail = formation.Creator.SVUMail,
                CreatorCity = formation.Creator.Profile.City,
                CreatorCountry = formation.Creator.Profile.Country,
                CreatorProfileBio = formation.Creator.Profile.Bio
            };
        }

    }
}

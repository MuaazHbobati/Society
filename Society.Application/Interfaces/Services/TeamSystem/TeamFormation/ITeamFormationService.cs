using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Society.Application.DTOs.TeamSystem.TeamFormation;

namespace Society.Application.Interfaces.Services.TeamSystem.TeamFormation
{
    public interface ITeamFormationService
    {
        Task<TeamFormationDetailsDto> CreateAsync(CreateTeamFormationDto dto, int creatorId);
        Task<List<TeamFormationListDto>> GetAllAsync();
        Task<FormationResponseDto> GetFormationsAsync(int userId, FormationRequestDto formationRequest);
        Task<TeamFormationDetailsDto> GetByIdAsync(int id);
    }
}

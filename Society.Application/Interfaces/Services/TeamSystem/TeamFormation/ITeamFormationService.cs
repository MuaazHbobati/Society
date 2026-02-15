using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Society.Application.DTOs.TeamSystem.TeamFormation;

namespace Society.Application.Interfaces.Services.TeamSystem.TeamFormation
{
    public interface ITeamFormationService
    {
        Task<TeamFormationDetailsDto> CreateAsync(CreateTeamFormationDto dto, Guid creatorId);
        Task<List<TeamFormationListDto>> GetAllAsync();
        Task<TeamFormationDetailsDto> GetByIdAsync(Guid id);
    }
}

using Society.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Application.DTOs.TeamSystem.TeamFormation;

namespace Society.Application.Interfaces.Repositories.TeamSystem
{
    public interface ITeamFormationRepository
    {
        Task AddAsync(TeamFormation formation);
        Task<TeamFormation> GetByIdAsync(int id);
        Task<List<TeamFormation>> GetAllAsync();
        Task<(List<TeamFormation> Items, bool HasMore)> GetFormationsAsync(
            FormationRequestDto request, int programId);
        Task SaveChangesAsync();
        Task<int?> GetProgramSubjectIdAsync(int programId, int subjectId);
        Task<bool> HasFormationForSubjectAsync(int userId, int subjectId);
    }
}

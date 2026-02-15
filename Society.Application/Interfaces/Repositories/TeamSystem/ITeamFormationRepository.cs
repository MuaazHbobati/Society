using Society.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Interfaces.Repositories.TeamSystem
{
    public interface ITeamFormationRepository
    {
        Task AddAsync(TeamFormation formation);
        Task<TeamFormation> GetByIdAsync(Guid id);
        Task<List<TeamFormation>> GetAllAsync();
        Task SaveChangesAsync();
    }
}

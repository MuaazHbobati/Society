using Society.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Interfaces.Repositories
{
    public interface IProgramRepository
    {
        Task<IEnumerable<Program>> GetAllProgramsAsync();
        Task<Program?> GetProgramByIdAsync(int programId);
        Task<IEnumerable<Subject>> GetSubjectsByProgramIdAsync(int programId);
    }
}

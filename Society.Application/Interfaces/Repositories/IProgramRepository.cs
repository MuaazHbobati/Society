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
        // جلب كل البرامج
        Task<IEnumerable<Program>> GetAllProgramsAsync();

        // جلب المواد حسب معرف البرنامج
        Task<IEnumerable<Subject>> GetSubjectsByProgramIdAsync(int programId);
    }
}

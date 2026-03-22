using Microsoft.EntityFrameworkCore;
using Society.Application.Interfaces.Repositories;
using Society.Domain.Entities;
using Society.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Infrastructure.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly SocietyDbContext _context;
        public ProgramRepository(SocietyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Program>> GetAllProgramsAsync()
        {
            return await _context.Programs.OrderBy(p => p.Name).ToListAsync();
        }


        public async Task<Program?> GetProgramByIdAsync(int programId)
        {
            return await _context.Programs.FindAsync(programId);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByProgramIdAsync(int programId)
        {
            return await _context.ProgramSubjects.Where(ps=> ps.ProgramId == programId)
                .Include(ps => ps.Subject)
                .Select(ps => ps.Subject)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }
    }
}

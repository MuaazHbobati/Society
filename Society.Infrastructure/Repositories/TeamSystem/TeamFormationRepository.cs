using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Society.Application.Interfaces.Repositories.TeamSystem;
using Society.Domain.Entities;
using Society.Infrastructure.Data;

namespace Society.Infrastructure.Repositories.TeamSystem
{
    public class TeamFormationRepository : ITeamFormationRepository
    {
        private readonly SocietyDbContext _context;

        public TeamFormationRepository(SocietyDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TeamFormation formation)
        {
             await _context.TeamFormations.AddAsync(formation);
        }

        public async Task<List<TeamFormation>> GetAllAsync()
        {
            return await _context.TeamFormations
                .Include(tf => tf.ProgramSubject)
                    .ThenInclude(ps => ps.Program)
                .Include(tf => tf.ProgramSubject)
                    .ThenInclude(ps => ps.Subject)
                .ToListAsync();
        }


        public async Task<TeamFormation> GetByIdAsync(int id)
        {
            return await _context.TeamFormations
                .Include(tf => tf.ProgramSubject)
                    .ThenInclude(ps => ps.Program)
                .Include(tf => tf.ProgramSubject)
                    .ThenInclude(ps => ps.Subject)
                .FirstOrDefaultAsync(tf => tf.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int?> GetProgramSubjectIdAsync(int programId, int subjectId)
        {
            var programSubject = await _context.ProgramSubjects
                .FirstOrDefaultAsync(ps => ps.ProgramId == programId && ps.SubjectId == subjectId);

            return programSubject?.Id;
        }
    }
}

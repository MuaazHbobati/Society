using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Society.Application.DTOs.TeamSystem.TeamFormation;
using Society.Application.Interfaces.Repositories.TeamSystem;
using Society.Domain.Entities;
using Society.Domain.Enums;
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
                .Include(tf => tf.Creator)
                    .ThenInclude(u => u.Person)
                .Include(tf => tf.Creator)
                    .ThenInclude(u => u.Profile)
                .Include(tf => tf.ProgramSubject)
                    .ThenInclude(ps => ps.Program)
                .Include(tf => tf.ProgramSubject)
                    .ThenInclude(ps => ps.Subject)
                .ToListAsync();
        }

        public async Task<TeamFormation> GetByIdAsync(int id)
        {
            return await _context.TeamFormations
                .Include(tf => tf.Creator)
                    .ThenInclude(u => u.Person)
                .Include(tf => tf.Creator)
                    .ThenInclude(u => u.Profile)
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

        public async Task<(List<TeamFormation> Items, bool HasMore)> GetFormationsAsync(
            FormationRequestDto formationRequest, int programId)
        {
            const int CardsNumberForEachScroll = 20;
            
            //Get All Formations by User Program only. 
            var formations = _context.TeamFormations
                        .Where(f => f.ProgramSubject.ProgramId == programId);

            //Filter Formations by Subject(if ther is)
            if (formationRequest.SubjectId.HasValue)
            {
                formations = formations.Where(f => f.ProgramSubject.SubjectId == formationRequest.SubjectId.Value);
            }

            formations = formations.OrderByDescending(f => f.CreatedAt);

            /****************************************************************/

            //To get all Formations After Scroll end.
            if (formationRequest.LastId.HasValue)
            {
                var lastDate = await _context.TeamFormations               
                    .Where(f => f.Id == formationRequest.LastId.Value)
                    .Select(f => f.CreatedAt)
                    .FirstOrDefaultAsync();

                formations = formations.Where(f => f.CreatedAt < lastDate);
            }

            var items = await formations
                .Take(CardsNumberForEachScroll + 1)
                .Include(f => f.Creator)
                    .ThenInclude(u => u.Person)
                .Include(f => f.Creator)
                    .ThenInclude(u => u.Profile)
                .Include(f => f.ProgramSubject)
                    .ThenInclude(ps => ps.Program)
                .Include(f => f.ProgramSubject)
                    .ThenInclude(ps => ps.Subject)
                .ToListAsync();

            bool hasMore = items.Count > CardsNumberForEachScroll;

            if (hasMore)
            {
                items.RemoveAt(items.Count - 1);
            }

            return (items, hasMore);
        }

        public async Task<bool> HasFormationForSubjectAsync(int userId, int subjectId)
        {
            var hasFormation = await _context.TeamFormations
                .AnyAsync(f => f.CreatorId == userId &&
                          f.ProgramSubject.SubjectId == subjectId);

            return hasFormation;
        }

    }
}

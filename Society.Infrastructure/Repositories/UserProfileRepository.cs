using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Society.Application.Interfaces.Repositories;
using Society.Domain.Entities;
using Society.Infrastructure.Data;

namespace Society.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private SocietyDbContext _context { get; set; }
        public UserProfileRepository(SocietyDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Profile.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task UpdateAsync(UserProfile profile)
        {
            _context.Profile.Update(profile);
            await _context.SaveChangesAsync();
        }
    }
}

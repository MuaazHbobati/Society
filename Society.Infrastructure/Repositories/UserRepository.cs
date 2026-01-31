using Society.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Society.Infrastructure.Data;
using Society.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private SocietyDbContext _context { get; set; }

        public UserRepository(SocietyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddPersonAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task AddProfileAsync(UserProfile userProfile)
        {
            _context.Profile.Add(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> isEmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> isUsernameExistAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
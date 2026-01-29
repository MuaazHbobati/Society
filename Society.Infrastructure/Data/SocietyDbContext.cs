using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Society.Domain.Entities;

namespace Society.Infrastructure.Data
{
    public class SocietyDbContext : DbContext
    {
        public SocietyDbContext(DbContextOptions<SocietyDbContext> options) : base(options)
        {
            
        }
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserProfile> Profile => Set<UserProfile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocietyDbContext).Assembly);
        }

    }
}

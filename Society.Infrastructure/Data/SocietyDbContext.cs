using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Society.Domain.Entities;

namespace Society.Infrastructure.Data
{
    public class SocietyDbContext : DbContext
    {
        public SocietyDbContext(DbContextOptions<SocietyDbContext> options) : base(options) 
        {
        }

        /******************** DbSets ********************/
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ProgramSubject> ProgramSubjects { get; set; }
        public DbSet<TeamFormation> TeamFormations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply entity configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocietyDbContext).Assembly);

            // --- Configure Composite Key for Many-to-Many ---
            modelBuilder.Entity<ProgramSubject>()
                .HasKey(ps => new { ps.ProgramId, ps.SubjectId });

            // --- Seed Data ---
            var iteId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            // Programs
            modelBuilder.Entity<Program>().HasData(
                new Program
                {
                    Id = iteId,
                    Name = "Information Technology Engineering"
                }
            );

            // Subjects
            var subjects = new List<Subject>
            {
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000001"), Code="BPG401", Name="Web Programming 1" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000002"), Code="BPG402", Name="Web Programming 2" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000003"), Code="DBS301", Name="Databases" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000004"), Code="ALG201", Name="Algorithms" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000005"), Code="OOP101", Name="OOP" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000006"), Code="NET101", Name="Networking" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000007"), Code="SEC201", Name="Cyber Security" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000008"), Code="AI101", Name="Intro to AI" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000009"), Code="SE201", Name="Software Engineering" },
                new Subject { Id = Guid.Parse("20000000-0000-0000-0000-000000000010"), Code="OS301", Name="Operating Systems" }
            };
            modelBuilder.Entity<Subject>().HasData(subjects);

            // ProgramSubjects (Many-to-Many)
            var programSubjects = subjects.Select(s => new ProgramSubject
            {
                ProgramId = iteId,
                SubjectId = s.Id
            }).ToList();
            modelBuilder.Entity<ProgramSubject>().HasData(programSubjects);

            base.OnModelCreating(modelBuilder);
        }
    }
}

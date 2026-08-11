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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocietyDbContext).Assembly);

           
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamFormation>()
                .HasOne(tf => tf.Creator)
                .WithMany(u => u.CreatedTeamFormations)
                .HasForeignKey(tf => tf.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamFormation>()
                .HasOne(tf => tf.Team)
                .WithOne(t => t.Formation)
                .HasForeignKey<Team>(t => t.FormationId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(tm => tm.TeamId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.User)
                .WithMany(u => u.TeamMemberships)
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamMember>()
                .HasIndex(tm => new { tm.TeamId, tm.UserId })
                .IsUnique();
        }
    }
}

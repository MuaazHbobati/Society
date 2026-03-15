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

           
            base.OnModelCreating(modelBuilder);

            // علاقة TeamFormation مع User (Creator)
            modelBuilder.Entity<TeamFormation>()
                .HasOne(tf => tf.Creator)
                .WithMany(u => u.CreatedTeamFormations)
                .HasForeignKey(tf => tf.CreatorId)
                .OnDelete(DeleteBehavior.Restrict); // منع حذف المستخدم إذا عنده formations

            // علاقة TeamFormation مع Team (one-to-one)
            modelBuilder.Entity<TeamFormation>()
                .HasOne(tf => tf.Team)
                .WithOne(t => t.Formation)
                .HasForeignKey<Team>(t => t.FormationId)
                .OnDelete(DeleteBehavior.Cascade); // إذا حذفنا التشكيل، ينحذف الفريق

            // علاقة TeamMember مع Team
            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(tm => tm.TeamId)
                .OnDelete(DeleteBehavior.Cascade); // إذا حذفنا الفريق، ينحذف الأعضاء

            // علاقة TeamMember مع User
            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.User)
                .WithMany(u => u.TeamMemberships)
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Restrict); // منع حذف المستخدم إذا هو عضو بفريق

            // منع duplicate entries (نفس المستخدم ما يقدر ينضم لنفس الفريق مرتين)
            modelBuilder.Entity<TeamMember>()
                .HasIndex(tm => new { tm.TeamId, tm.UserId })
                .IsUnique();
        }
    }
}

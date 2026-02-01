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

        /********************DbSets********************/

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserProfile> Profile => Set<UserProfile>();
        public DbSet<PartnerRequest> PartnerRequests { get; set; }
        public DbSet<PartnerApplication> Applications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocietyDbContext).Assembly);

           
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PartnerApplication>().HasOne(a => a.Applicant)
                .WithMany(u => u.Application).HasForeignKey(a => a.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PartnerApplication>().HasOne(a => a.PartnerRequest)
               .WithMany(r => r.Applications).HasForeignKey(a => a.RequestId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PartnerRequest>().HasOne(r => r.Creator)
               .WithMany(u => u.CreatedPartnerRequests).HasForeignKey(r => r.CreatorId)
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}


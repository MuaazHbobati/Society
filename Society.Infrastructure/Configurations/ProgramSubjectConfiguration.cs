using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Society.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Infrastructure.Configurations
{
    public class ProgramSubjectConfiguration : IEntityTypeConfiguration<ProgramSubject>
    {
        public void Configure(EntityTypeBuilder<ProgramSubject> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder
                .HasOne(ps => ps.Program)
                .WithMany(p => p.ProgramSubjects)
                .HasForeignKey(ps => ps.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ps => ps.Subject)
                .WithMany(s => s.ProgramSubjects)
                .HasForeignKey(ps => ps.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(ps => new { ps.ProgramId, ps.SubjectId })
                   .IsUnique();
        }
    }
}

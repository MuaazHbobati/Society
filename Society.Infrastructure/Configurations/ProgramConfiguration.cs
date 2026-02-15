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
    public class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            // 🔹 Relation: Program -> ProgramSubjects
            builder
                .HasMany(p => p.ProgramSubjects)
                .WithOne(ps => ps.Program)
                .HasForeignKey(ps => ps.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

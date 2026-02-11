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

            builder.HasIndex(ps => new { ps.ProgramId, ps.SubjectId })
                   .IsUnique();
        }
    }

}

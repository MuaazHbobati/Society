using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Society.Domain.Entities;

namespace Society.Infrastructure.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}

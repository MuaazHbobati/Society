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
    public class TeamFormationConfiguration : IEntityTypeConfiguration<TeamFormation>
    {
        public void Configure(EntityTypeBuilder<TeamFormation> builder)
        {
            builder.HasKey(tf => tf.Id);

            builder.Property(tf => tf.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(tf => tf.Description)
                   .HasMaxLength(1000);

            builder.Property(tf => tf.Status)
                   .HasConversion<int>();

            builder.HasIndex(tf => tf.Status);
        }
    }

}

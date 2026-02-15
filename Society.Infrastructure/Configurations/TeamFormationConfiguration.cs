using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Society.Domain.Entities;

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

            // 🔹 Relation with ProgramSubject (Many Formations -> One ProgramSubject)
            builder
                .HasOne(tf => tf.ProgramSubject)
                .WithMany(ps => ps.TeamFormations)
                .HasForeignKey(tf => tf.ProgramSubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Relation with Team (One Formation -> One Team)
            builder
                .HasOne(tf => tf.Team)
                .WithOne(t => t.Formation)
                .HasForeignKey<Team>(t => t.FormationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

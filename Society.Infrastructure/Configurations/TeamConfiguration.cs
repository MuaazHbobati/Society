using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Society.Domain.Entities;

namespace Society.Infrastructure.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            // Relation with TeamFormation (1-1)
            builder
                .HasOne(t => t.Formation)
                .WithOne(tf => tf.Team)
                .HasForeignKey<Team>(t => t.FormationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation with ProgramSubject (Many Teams -> One ProgramSubject)
            builder
                .HasOne(t => t.ProgramSubject)
                .WithMany(ps => ps.Teams)
                .HasForeignKey(t => t.ProgramSubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation with TeamMembers (1 Team -> Many Members)
            builder
                .HasMany(t => t.Members)
                .WithOne(tm => tm.Team)
                .HasForeignKey(tm => tm.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

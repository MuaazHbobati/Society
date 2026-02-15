using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Society.Domain.Entities;

namespace Society.Infrastructure.Configurations
{
    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasKey(tm => tm.Id);

            builder.Property(tm => tm.Role)
                   .HasConversion<int>();

            builder.HasIndex(tm => new { tm.TeamId, tm.UserId })
                   .IsUnique();

            // 🔹 TeamMember -> Team
            builder
                .HasOne(tm => tm.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(tm => tm.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
            // إذا انحذف Team نحذف الأعضاء

            // 🔹 TeamMember -> User
            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            // منع cascade لتجنب multiple cascade paths
        }
    }
}

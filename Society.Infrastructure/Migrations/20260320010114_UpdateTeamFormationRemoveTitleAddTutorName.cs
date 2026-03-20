using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeamFormationRemoveTitleAddTutorName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TeamFormations",
                newName: "TutorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TutorName",
                table: "TeamFormations",
                newName: "Title");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClassNameColumnToTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamFormations_Users_CreatorId",
                table: "TeamFormations");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamFormations_FormationId",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "TeamFormations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamFormations_Users_CreatorId",
                table: "TeamFormations",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamFormations_FormationId",
                table: "Teams",
                column: "FormationId",
                principalTable: "TeamFormations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamFormations_Users_CreatorId",
                table: "TeamFormations");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamFormations_FormationId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "TeamFormations");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamFormations_Users_CreatorId",
                table: "TeamFormations",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamFormations_FormationId",
                table: "Teams",
                column: "FormationId",
                principalTable: "TeamFormations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

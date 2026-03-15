using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeamFormations_CreatorId",
                table: "TeamFormations",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamFormations_Users_CreatorId",
                table: "TeamFormations",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamFormations_Users_CreatorId",
                table: "TeamFormations");

            migrationBuilder.DropIndex(
                name: "IX_TeamFormations_CreatorId",
                table: "TeamFormations");
        }
    }
}

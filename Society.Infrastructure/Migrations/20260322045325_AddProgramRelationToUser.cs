using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramRelationToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "UserProfiles");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProgramId",
                table: "Users",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Programs_ProgramId",
                table: "Users",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Programs_ProgramId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProgramId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

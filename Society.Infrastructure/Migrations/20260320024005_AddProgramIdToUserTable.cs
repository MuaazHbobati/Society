using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramIdToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Users");
        }
    }
}

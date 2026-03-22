using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSVUMailAndDeleteFatherName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "SVUMail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SVUMail",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Persons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}

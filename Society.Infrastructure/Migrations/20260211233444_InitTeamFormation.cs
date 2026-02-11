using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitTeamFormation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramSubjects",
                columns: table => new
                {
                    ProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramSubjects", x => new { x.ProgramId, x.SubjectId });
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamFormations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MaxMembers = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CurrentMembersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamFormations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgramSubjects",
                columns: new[] { "ProgramId", "SubjectId", "Id" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Information Technology Engineering" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "Name", "ProgramId" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "BPG401", "Web Programming 1", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "BPG402", "Web Programming 2", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "DBS301", "Databases", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "ALG201", "Algorithms", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000005"), "OOP101", "OOP", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000006"), "NET101", "Networking", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000007"), "SEC201", "Cyber Security", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000008"), "AI101", "Intro to AI", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000009"), "SE201", "Software Engineering", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20000000-0000-0000-0000-000000000010"), "OS301", "Operating Systems", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramSubjects_ProgramId_SubjectId",
                table: "ProgramSubjects",
                columns: new[] { "ProgramId", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamFormations_Status",
                table: "TeamFormations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId_UserId",
                table: "TeamMembers",
                columns: new[] { "TeamId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "ProgramSubjects");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "TeamFormations");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

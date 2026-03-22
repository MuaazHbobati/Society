using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultUniversityValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // إضافة القيمة الافتراضية لعمود University في جدول UserProfiles
            migrationBuilder.Sql(
                @"UPDATE UserProfiles 
                  SET University = 'Syrian Virtual University (SVU)' 
                  WHERE University IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // العودة إلى الحالة السابقة (إرجاع القيم إلى NULL)
            migrationBuilder.Sql(
                @"UPDATE UserProfiles 
                  SET University = NULL 
                  WHERE University = 'Syrian Virtual University (SVU)'");
        }
    }
}
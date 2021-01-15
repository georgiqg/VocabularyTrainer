using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyTrainer.Migrations
{
    public partial class RemoveUnnecessaryFieldLanguageTestName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageTestName",
                table: "LanguageTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageTestName",
                table: "LanguageTest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

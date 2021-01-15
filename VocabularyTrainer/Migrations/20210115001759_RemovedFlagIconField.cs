using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyTrainer.Migrations
{
    public partial class RemovedFlagIconField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagIconUrl",
                table: "Language");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlagIconUrl",
                table: "Language",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

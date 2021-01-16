using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyTrainer.Migrations
{
    public partial class WordArticalNotMandatory_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Gender_GenderId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_Article_ArticleId",
                table: "Word");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Word",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Gender_GenderId",
                table: "Article",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Article_ArticleId",
                table: "Word",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Gender_GenderId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_Article_ArticleId",
                table: "Word");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Word",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Gender_GenderId",
                table: "Article",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Article_ArticleId",
                table: "Word",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

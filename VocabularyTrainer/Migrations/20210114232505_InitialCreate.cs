using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyTrainer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenderColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlagUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlagIconUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "TestType",
                columns: table => new
                {
                    TestTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestType", x => x.TestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefiniteArticle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IndefiniteArticle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Article_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Article_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.DeckId);
                    table.ForeignKey(
                        name: "FK_Deck_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTest",
                columns: table => new
                {
                    LanguageTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestTypeId = table.Column<int>(type: "int", nullable: false),
                    LanguageTestName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTest", x => x.LanguageTestId);
                    table.ForeignKey(
                        name: "FK_LanguageTest_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageTest_TestType_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestType",
                        principalColumn: "TestTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Singular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Plural = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Meaning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    DeckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.WordId);
                    table.ForeignKey(
                        name: "FK_Word_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Word_Deck_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "DeckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestLog",
                columns: table => new
                {
                    TestLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordsCount = table.Column<int>(type: "int", nullable: false),
                    RightAnswers = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LanguageTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestLog", x => x.TestLogId);
                    table.ForeignKey(
                        name: "FK_TestLog_LanguageTest_LanguageTestId",
                        column: x => x.LanguageTestId,
                        principalTable: "LanguageTest",
                        principalColumn: "LanguageTestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_GenderId",
                table: "Article",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_LanguageId",
                table: "Article",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Deck_LanguageId",
                table: "Deck",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTest_LanguageId",
                table: "LanguageTest",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTest_TestTypeId",
                table: "LanguageTest",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestLog_LanguageTestId",
                table: "TestLog",
                column: "LanguageTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Word_ArticleId",
                table: "Word",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Word_DeckId",
                table: "Word",
                column: "DeckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestLog");

            migrationBuilder.DropTable(
                name: "Word");

            migrationBuilder.DropTable(
                name: "LanguageTest");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "TestType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}

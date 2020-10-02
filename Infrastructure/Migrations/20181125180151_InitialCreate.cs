using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zetutech.Web.Api.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QUESTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QUESTIONOPTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QUESITON_ID = table.Column<int>(nullable: false),
                    TITLE = table.Column<string>(nullable: true),
                    IS_CORRECT = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTIONOPTIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUESTIONOPTIONS_QUESTIONS_QUESITON_ID",
                        column: x => x.QUESITON_ID,
                        principalTable: "QUESTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QUESTIONOPTIONS_QUESITON_ID",
                table: "QUESTIONOPTIONS",
                column: "QUESITON_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QUESTIONOPTIONS");

            migrationBuilder.DropTable(
                name: "QUESTIONS");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolio.Migrations
{
    public partial class LinkKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectMadeId = table.Column<int>(type: "int", nullable: false),
                    CommentRate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_Rate_ProjectMade_ProjectMadeId",
                        column: x => x.ProjectMadeId,
                        principalTable: "ProjectMade",
                        principalColumn: "ProjectMadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rate_ProjectMadeId",
                table: "Rate",
                column: "ProjectMadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rate");
        }
    }
}

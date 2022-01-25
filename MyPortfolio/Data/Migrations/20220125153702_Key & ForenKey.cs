using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolio.Data.Migrations
{
    public partial class KeyForenKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackEndTechnology",
                columns: table => new
                {
                    BackEndTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackEndTechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackEndTechnology", x => x.BackEndTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseTechnology",
                columns: table => new
                {
                    DatabaseTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatabaseTechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseTechnology", x => x.DatabaseTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "FrontEndTechnology",
                columns: table => new
                {
                    FrontEndTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontEndName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontEndTechnology", x => x.FrontEndTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "OtherTechnology",
                columns: table => new
                {
                    OtherTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherTechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherTechnology", x => x.OtherTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Collaboratorss",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackEndTechnologyId = table.Column<int>(type: "int", nullable: false),
                    FrontEndTechnologyId = table.Column<int>(type: "int", nullable: false),
                    OtherTechnologyId = table.Column<int>(type: "int", nullable: false),
                    DatabaseTechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaboratorss", x => x.CollaboratorId);
                    table.ForeignKey(
                        name: "FK_Collaboratorss_BackEndTechnology_BackEndTechnologyId",
                        column: x => x.BackEndTechnologyId,
                        principalTable: "BackEndTechnology",
                        principalColumn: "BackEndTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaboratorss_DatabaseTechnology_DatabaseTechnologyId",
                        column: x => x.DatabaseTechnologyId,
                        principalTable: "DatabaseTechnology",
                        principalColumn: "DatabaseTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaboratorss_FrontEndTechnology_FrontEndTechnologyId",
                        column: x => x.FrontEndTechnologyId,
                        principalTable: "FrontEndTechnology",
                        principalColumn: "FrontEndTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaboratorss_OtherTechnology_OtherTechnologyId",
                        column: x => x.OtherTechnologyId,
                        principalTable: "OtherTechnology",
                        principalColumn: "OtherTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMades",
                columns: table => new
                {
                    ProjectMadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectMadeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectMadeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackEndTechnologyId = table.Column<int>(type: "int", nullable: false),
                    FrontEndTechnologyId = table.Column<int>(type: "int", nullable: false),
                    OtherTechnologyId = table.Column<int>(type: "int", nullable: false),
                    DatabaseTechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMades", x => x.ProjectMadeId);
                    table.ForeignKey(
                        name: "FK_ProjectMades_BackEndTechnology_BackEndTechnologyId",
                        column: x => x.BackEndTechnologyId,
                        principalTable: "BackEndTechnology",
                        principalColumn: "BackEndTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMades_DatabaseTechnology_DatabaseTechnologyId",
                        column: x => x.DatabaseTechnologyId,
                        principalTable: "DatabaseTechnology",
                        principalColumn: "DatabaseTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMades_FrontEndTechnology_FrontEndTechnologyId",
                        column: x => x.FrontEndTechnologyId,
                        principalTable: "FrontEndTechnology",
                        principalColumn: "FrontEndTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMades_OtherTechnology_OtherTechnologyId",
                        column: x => x.OtherTechnologyId,
                        principalTable: "OtherTechnology",
                        principalColumn: "OtherTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalUsers",
                columns: table => new
                {
                    PersonalUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthplace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalUsers", x => x.PersonalUserId);
                    table.ForeignKey(
                        name: "FK_PersonalUsers_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaboratorss_BackEndTechnologyId",
                table: "Collaboratorss",
                column: "BackEndTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboratorss_DatabaseTechnologyId",
                table: "Collaboratorss",
                column: "DatabaseTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboratorss_FrontEndTechnologyId",
                table: "Collaboratorss",
                column: "FrontEndTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboratorss_OtherTechnologyId",
                table: "Collaboratorss",
                column: "OtherTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalUsers_SkillId",
                table: "PersonalUsers",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMades_BackEndTechnologyId",
                table: "ProjectMades",
                column: "BackEndTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMades_DatabaseTechnologyId",
                table: "ProjectMades",
                column: "DatabaseTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMades_FrontEndTechnologyId",
                table: "ProjectMades",
                column: "FrontEndTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMades_OtherTechnologyId",
                table: "ProjectMades",
                column: "OtherTechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaboratorss");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "PersonalUsers");

            migrationBuilder.DropTable(
                name: "ProjectMades");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "BackEndTechnology");

            migrationBuilder.DropTable(
                name: "DatabaseTechnology");

            migrationBuilder.DropTable(
                name: "FrontEndTechnology");

            migrationBuilder.DropTable(
                name: "OtherTechnology");
        }
    }
}

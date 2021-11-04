using Microsoft.EntityFrameworkCore.Migrations;

namespace TVTProject2.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRoles_People_PersonId",
                table: "ProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRoles_PersonId",
                table: "ProjectRoles");

            migrationBuilder.CreateTable(
                name: "PersonProject",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProject", x => new { x.PeopleId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_PersonProject_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProject_ProjectsId",
                table: "PersonProject",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonProject");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRoles_PersonId",
                table: "ProjectRoles",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRoles_People_PersonId",
                table: "ProjectRoles",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

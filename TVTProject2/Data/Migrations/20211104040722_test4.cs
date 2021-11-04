using Microsoft.EntityFrameworkCore.Migrations;

namespace TVTProject2.Data.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRoles_PersonId",
                table: "ProjectRoles",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ProjectId",
                table: "People",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Projects_ProjectId",
                table: "People",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRoles_People_PersonId",
                table: "ProjectRoles",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Projects_ProjectId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRoles_People_PersonId",
                table: "ProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRoles_PersonId",
                table: "ProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_People_ProjectId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "People");
        }
    }
}

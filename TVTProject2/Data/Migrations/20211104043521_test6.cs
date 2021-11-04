using Microsoft.EntityFrameworkCore.Migrations;

namespace TVTProject2.Data.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Projects_ProjectId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ProjectId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRoles_ProjectId",
                table: "ProjectRoles",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRoles_Projects_ProjectId",
                table: "ProjectRoles",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRoles_Projects_ProjectId",
                table: "ProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRoles_ProjectId",
                table: "ProjectRoles");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "People",
                type: "int",
                nullable: true);

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
        }
    }
}

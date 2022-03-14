using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class modtosprints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "sprint",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sprint_ProjectId",
                table: "sprint",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_sprint_project_ProjectId",
                table: "sprint",
                column: "ProjectId",
                principalTable: "project",
                principalColumn: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sprint_project_ProjectId",
                table: "sprint");

            migrationBuilder.DropIndex(
                name: "IX_sprint_ProjectId",
                table: "sprint");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "sprint");
        }
    }
}

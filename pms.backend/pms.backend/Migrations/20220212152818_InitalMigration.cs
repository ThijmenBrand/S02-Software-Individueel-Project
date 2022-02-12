using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pms.backend.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projectsModel",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDiscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectsModel", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "tasksModel",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDiscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasksModel", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_tasksModel_projectsModel_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projectsModel",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasksModel_ProjectId",
                table: "tasksModel",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasksModel");

            migrationBuilder.DropTable(
                name: "projectsModel");
        }
    }
}

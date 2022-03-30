using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProjectOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "sprint",
                columns: table => new
                {
                    SprintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SprintName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SprintStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SprintEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sprint", x => x.SprintId);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SprintId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "asset",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_asset_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "link",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_link_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "time",
                columns: table => new
                {
                    TimeRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeRecordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeRecordTiming = table.Column<double>(type: "float", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_time", x => x.TimeRecordId);
                    table.ForeignKey(
                        name: "FK_time_task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asset_ProjectId",
                table: "asset",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_link_ProjectId",
                table: "link",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_time_TaskId",
                table: "time",
                column: "TaskId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asset");

            migrationBuilder.DropTable(
                name: "link");

            migrationBuilder.DropTable(
                name: "sprint");

            migrationBuilder.DropTable(
                name: "time");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "task");
        }
    }
}

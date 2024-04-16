using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "#Employment",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyID = table.Column<short>(type: "smallint", nullable: false),
                    TaskListCategoryID = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_#Employment", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "#TaskResponsibleUser",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_#TaskResponsibleUser", x => new { x.TaskID, x.UserID });
                });

            migrationBuilder.CreateTable(
                name: "#TaskUserCacheADM",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    TaskListCategoryID = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_#TaskUserCacheADM", x => new { x.TaskID, x.UserID, x.TaskListCategoryID });
                });

            migrationBuilder.CreateTable(
                name: "#UserTaskListCategory",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    TaskListCategoryID = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_#UserTaskListCategory", x => new { x.UserID, x.TaskListCategoryID });
                });

            migrationBuilder.CreateTable(
                name: "ListCategories",
                columns: table => new
                {
                    ID = table.Column<byte>(type: "smallint", nullable: false),
                    PermissionExtID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetID = table.Column<int>(type: "integer", nullable: false),
                    ApprovalWith = table.Column<int>(type: "integer", nullable: true),
                    EscalatedTo = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    RequestedBy = table.Column<int>(type: "integer", nullable: false),
                    WorkTypeID = table.Column<short>(type: "smallint", nullable: false),
                    Archived = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "#Employment");

            migrationBuilder.DropTable(
                name: "#TaskResponsibleUser");

            migrationBuilder.DropTable(
                name: "#TaskUserCacheADM");

            migrationBuilder.DropTable(
                name: "#UserTaskListCategory");

            migrationBuilder.DropTable(
                name: "ListCategories");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

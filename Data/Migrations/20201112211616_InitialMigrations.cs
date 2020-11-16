using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "PermissionTypes",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_PermissionTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Permissions",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>("nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>("nvarchar(max)", nullable: true),
                    PermissionTypeId = table.Column<int>("int", nullable: false),
                    PermissionDate = table.Column<DateTime>("datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        "FK_Permissions_PermissionTypes_PermissionTypeId",
                        x => x.PermissionTypeId,
                        "PermissionTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Permissions_PermissionTypeId",
                "Permissions",
                "PermissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Permissions");

            migrationBuilder.DropTable(
                "PermissionTypes");
        }
    }
}
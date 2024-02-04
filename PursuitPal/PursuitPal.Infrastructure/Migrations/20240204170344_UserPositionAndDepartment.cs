using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PursuitPal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserPositionAndDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223)),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("d8fd13b8-d7bc-4637-8c7b-5b5cd140863e")),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name", "NameShort", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Cybersecurity", null, null, null },
                    { 2, "Quality Assurance", "QA", null, null },
                    { 3, "Network Administration", "NetAdmin", null, null },
                    { 4, "Information Technology Support", "IT Support", null, null },
                    { 5, "Software Development", "Dev", null, null },
                    { 6, "Research and Development", "R&D", null, null },
                    { 7, "Database Management", "DB", null, null },
                    { 8, "User Experience", "UX", null, null },
                    { 9, "Infrastructure and Cloud", "DevOps", null, null },
                    { 10, "Systems Administration", "SysAdmin", null, null },
                    { 11, "Business Intelligence", "BI", null, null },
                    { 12, "Customer Support", null, null, null },
                    { 13, "Sales and Marketing", null, null, null },
                    { 14, "Human Resources", "HR", null, null },
                    { 15, "Finance and Accounting", null, null, null },
                    { 16, "Legal and Compliance", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Department_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Department_DepartmentId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Users");
        }
    }
}

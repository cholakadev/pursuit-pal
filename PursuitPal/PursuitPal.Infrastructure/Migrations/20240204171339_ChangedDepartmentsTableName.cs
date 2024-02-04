using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursuitPal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDepartmentsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Department_DepartmentId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 17, 3, 43, 745, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Department_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

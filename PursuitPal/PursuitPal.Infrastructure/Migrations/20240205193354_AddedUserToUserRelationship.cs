using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursuitPal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserToUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReportsTo",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportsTo",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 17, 13, 38, 947, DateTimeKind.Utc).AddTicks(3071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 5, 19, 33, 53, 878, DateTimeKind.Utc).AddTicks(2048));

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
        }
    }
}

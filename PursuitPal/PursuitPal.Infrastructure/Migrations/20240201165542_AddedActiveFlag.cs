using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursuitPal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedActiveFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 1, 16, 55, 42, 204, DateTimeKind.Utc).AddTicks(4674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 1, 13, 22, 5, 654, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Goals",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "GoalFeedback",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "GoalFeedback");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 1, 13, 22, 5, 654, DateTimeKind.Utc).AddTicks(5356),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 1, 16, 55, 42, 204, DateTimeKind.Utc).AddTicks(4674));
        }
    }
}

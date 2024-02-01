using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursuitPal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCreatedByDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 1, 16, 55, 42, 204, DateTimeKind.Utc).AddTicks(4674));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 1, 16, 55, 42, 204, DateTimeKind.Utc).AddTicks(4674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}

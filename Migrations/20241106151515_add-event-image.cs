using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManageApp.Migrations
{
    /// <inheritdoc />
    public partial class addeventimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 6, 15, 15, 11, 518, DateTimeKind.Utc).AddTicks(4132), "$2a$10$iZiwX04ngJCbhpUWygGjsuoIsS4CyuFeNTocCEHGjyUhMgQrEQIue" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 6, 11, 39, 38, 417, DateTimeKind.Utc).AddTicks(2156), "$2a$10$IJUiOnTMGvKNGUt2JnqjAuiAZHPDAj5e5RrGqCk.QyiC4d3CgBiYO" });
        }
    }
}

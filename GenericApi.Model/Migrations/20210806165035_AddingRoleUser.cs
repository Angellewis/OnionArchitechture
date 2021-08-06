using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class AddingRoleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 6, 16, 50, 35, 53, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 6, 12, 50, 35, 53, DateTimeKind.Local).AddTicks(8877) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 26, 15, 24, 55, 583, DateTimeKind.Unspecified).AddTicks(6357), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 7, 26, 11, 24, 55, 583, DateTimeKind.Local).AddTicks(6858) });
        }
    }
}

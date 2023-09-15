using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class nullableNavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(2136), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(2136), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(2141), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(1589), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 11, 5, 689, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(586), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(589), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(589), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(308), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 6, 25, 433, DateTimeKind.Unspecified).AddTicks(309), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}

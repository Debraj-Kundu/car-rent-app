using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class one_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentedCars_CarId",
                table: "RentedCars");

            migrationBuilder.DropIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9221), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9221), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9223), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9223), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 13, 31, 36, 335, DateTimeKind.Unspecified).AddTicks(9121), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_CarId",
                table: "RentedCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentedCars_CarId",
                table: "RentedCars");

            migrationBuilder.DropIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars");

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

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_CarId",
                table: "RentedCars",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars",
                column: "UserId",
                unique: true);
        }
    }
}

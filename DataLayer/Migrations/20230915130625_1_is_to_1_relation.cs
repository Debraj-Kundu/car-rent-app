using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class _1_is_to_1_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_RentedCars_Cars_CarId",
                table: "RentedCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentedCars_Users_UserId",
                table: "RentedCars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedCars_Cars_CarId",
                table: "RentedCars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentedCars_Users_UserId",
                table: "RentedCars");

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
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7975), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7975), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7978), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7978), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7980), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7829), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 15, 11, 47, 18, 212, DateTimeKind.Unspecified).AddTicks(7830), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}

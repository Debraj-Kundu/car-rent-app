using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class SeedData1_14092023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvailabilityStatus", "CreatedOnDate", "Maker", "Model", "ModifiedOnDate", "RentalPrice", "VehicalId" },
                values: new object[,]
                {
                    { 2, true, new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 0, 0, 0, 0)), "Hyundai", "i20", new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 0, 0, 0, 0)), 64000m, "2" },
                    { 3, true, new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 0, 0, 0, 0)), "Maruti", "Alto", new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 0, 0, 0, 0)), 46000m, "3" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4834), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4698), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}

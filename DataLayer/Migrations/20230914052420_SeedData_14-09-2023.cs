using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class SeedData_14092023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marker",
                table: "Cars",
                newName: "Maker");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvailabilityStatus", "CreatedOnDate", "Maker", "Model", "ModifiedOnDate", "RentalPrice", "VehicalId" },
                values: new object[] { 1, true, new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4834), new TimeSpan(0, 0, 0, 0, 0)), "Maruti", "Swift Desire", new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, 0, 0, 0, 0)), 58000m, "1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4698), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 24, 19, 902, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Maker",
                table: "Cars",
                newName: "Marker");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 13, 14, 58, 12, 561, DateTimeKind.Unspecified).AddTicks(3504), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 13, 14, 58, 12, 561, DateTimeKind.Unspecified).AddTicks(3509), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}

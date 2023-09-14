using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class PK_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedCars_Cars_CarId",
                table: "RentedCars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentedCars_Users_UserId",
                table: "RentedCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedCars",
                table: "RentedCars");

            migrationBuilder.DropIndex(
                name: "IX_RentedCars_CarId",
                table: "RentedCars");

            migrationBuilder.DropIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "RentalId",
                table: "RentedCars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CarVehicalId",
                table: "RentedCars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "RentedCars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedCars",
                table: "RentedCars",
                column: "RentalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "VehicalId");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "VehicalId",
                keyValue: "1",
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8693), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8693), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "VehicalId",
                keyValue: "2",
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "VehicalId",
                keyValue: "3",
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "1",
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_CarVehicalId",
                table: "RentedCars",
                column: "CarVehicalId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_UserId1",
                table: "RentedCars",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RentedCars_Cars_CarVehicalId",
                table: "RentedCars",
                column: "CarVehicalId",
                principalTable: "Cars",
                principalColumn: "VehicalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentedCars_Users_UserId1",
                table: "RentedCars",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedCars_Cars_CarVehicalId",
                table: "RentedCars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentedCars_Users_UserId1",
                table: "RentedCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedCars",
                table: "RentedCars");

            migrationBuilder.DropIndex(
                name: "IX_RentedCars_CarVehicalId",
                table: "RentedCars");

            migrationBuilder.DropIndex(
                name: "IX_RentedCars_UserId1",
                table: "RentedCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarVehicalId",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RentedCars");

            migrationBuilder.AlterColumn<string>(
                name: "RentalId",
                table: "RentedCars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedCars",
                table: "RentedCars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 5, 27, 31, 729, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_CarId",
                table: "RentedCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars",
                column: "UserId");

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
    }
}

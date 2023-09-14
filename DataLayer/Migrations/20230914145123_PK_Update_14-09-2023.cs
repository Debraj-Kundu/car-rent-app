using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class PK_Update_14092023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
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

            migrationBuilder.DropIndex(
                name: "IX_Cars_VehicalId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "CarVehicalId",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "VehicalId",
                table: "Cars");

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
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6716), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6719), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6719), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6608), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 14, 14, 51, 23, 466, DateTimeKind.Unspecified).AddTicks(6609), new TimeSpan(0, 0, 0, 0, 0)) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RentalId",
                table: "RentedCars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "VehicalId",
                table: "Cars",
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

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "VehicalId", "AvailabilityStatus", "CreatedOnDate", "Id", "Maker", "Model", "ModifiedOnDate", "RentalPrice" },
                values: new object[,]
                {
                    { "1", true, new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8693), new TimeSpan(0, 0, 0, 0, 0)), 1, "Maruti", "Swift Desire", new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8693), new TimeSpan(0, 0, 0, 0, 0)), 58000m },
                    { "2", true, new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 0, 0, 0, 0)), 2, "Hyundai", "i20", new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8696), new TimeSpan(0, 0, 0, 0, 0)), 64000m },
                    { "3", true, new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 0, 0, 0, 0)), 3, "Maruti", "Alto", new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8698), new TimeSpan(0, 0, 0, 0, 0)), 46000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedOnDate", "Email", "Id", "ModifiedOnDate", "Name", "Password", "Role" },
                values: new object[] { "1", new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 0, 0, 0, 0)), "user1@user.com", 1, new DateTimeOffset(new DateTime(2023, 9, 14, 5, 39, 9, 126, DateTimeKind.Unspecified).AddTicks(8608), new TimeSpan(0, 0, 0, 0, 0)), "UserOne", "User@123", "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_CarVehicalId",
                table: "RentedCars",
                column: "CarVehicalId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_UserId1",
                table: "RentedCars",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VehicalId",
                table: "Cars",
                column: "VehicalId",
                unique: true);

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
    }
}

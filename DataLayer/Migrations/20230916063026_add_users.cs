using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class add_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(4063), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(4063), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(4065), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(4065), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(4067), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(4067), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOnDate", "ModifiedOnDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOnDate", "Email", "ModifiedOnDate", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3974), new TimeSpan(0, 0, 0, 0, 0)), "user2@user.com", new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3974), new TimeSpan(0, 0, 0, 0, 0)), "UserTwo", "User@123", "User" },
                    { 3, new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, 0, 0, 0, 0)), "user3@user.com", new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, 0, 0, 0, 0)), "UserThree", "User@123", "User" },
                    { 4, new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3978), new TimeSpan(0, 0, 0, 0, 0)), "admin1@admin.com", new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3978), new TimeSpan(0, 0, 0, 0, 0)), "AdminOne", "Admin@123", "Admin" },
                    { 5, new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3980), new TimeSpan(0, 0, 0, 0, 0)), "admin2@admin.com", new DateTimeOffset(new DateTime(2023, 9, 16, 6, 30, 26, 760, DateTimeKind.Unspecified).AddTicks(3980), new TimeSpan(0, 0, 0, 0, 0)), "AdminOne", "Admin@123", "Admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}

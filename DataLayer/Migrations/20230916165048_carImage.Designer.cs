﻿// <auto-generated />
using System;
using DataLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(CarDomainDbContext))]
    [Migration("20230916165048_carImage")]
    partial class carImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataLayer.Entity.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AvailabilityStatus")
                        .HasColumnType("bit");

                    b.Property<string>("CarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailabilityStatus = true,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4908), new TimeSpan(0, 0, 0, 0, 0)),
                            Maker = "Maruti",
                            Model = "Swift Desire",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4909), new TimeSpan(0, 0, 0, 0, 0)),
                            RentalPrice = 58000m
                        },
                        new
                        {
                            Id = 2,
                            AvailabilityStatus = true,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4912), new TimeSpan(0, 0, 0, 0, 0)),
                            Maker = "Hyundai",
                            Model = "i20",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4912), new TimeSpan(0, 0, 0, 0, 0)),
                            RentalPrice = 64000m
                        },
                        new
                        {
                            Id = 3,
                            AvailabilityStatus = true,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, 0, 0, 0, 0)),
                            Maker = "Maruti",
                            Model = "Alto",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4914), new TimeSpan(0, 0, 0, 0, 0)),
                            RentalPrice = 46000m
                        });
                });

            modelBuilder.Entity("DataLayer.Entity.RentedCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DateRented")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReturn")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("ModifiedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("RentedCars");
                });

            modelBuilder.Entity("DataLayer.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("CreatedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "user1@user.com",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "UserOne",
                            Password = "User@123",
                            Role = "User"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4822), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "user2@user.com",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4822), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "UserTwo",
                            Password = "User@123",
                            Role = "User"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4824), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "user3@user.com",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4824), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "UserThree",
                            Password = "User@123",
                            Role = "User"
                        },
                        new
                        {
                            Id = 4,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4826), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "admin1@admin.com",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4826), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "AdminOne",
                            Password = "Admin@123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 5,
                            CreatedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4828), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "admin2@admin.com",
                            ModifiedOnDate = new DateTimeOffset(new DateTime(2023, 9, 16, 16, 50, 48, 42, DateTimeKind.Unspecified).AddTicks(4828), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "AdminTwo",
                            Password = "Admin@123",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("DataLayer.Entity.RentedCar", b =>
                {
                    b.HasOne("DataLayer.Entity.Car", "Car")
                        .WithMany("RentedCar")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entity.User", "User")
                        .WithMany("RentedCar")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entity.Car", b =>
                {
                    b.Navigation("RentedCar");
                });

            modelBuilder.Entity("DataLayer.Entity.User", b =>
                {
                    b.Navigation("RentedCar");
                });
#pragma warning restore 612, 618
        }
    }
}

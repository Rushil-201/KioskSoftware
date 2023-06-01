﻿// <auto-generated />
using System;
using Kiosk.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kiosk.DAL.Migrations
{
    [DbContext(typeof(KioskDbContext))]
    [Migration("20230601011412_KioskSoftware-V1")]
    partial class KioskSoftwareV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kiosk.DAL.DBModels.Concert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableCapacity")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PerformanceDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Concert", t =>
                        {
                            t.HasCheckConstraint("check_Availability_constraint", "[AvailableCapacity] >= 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("a07d385e-a8db-44a5-a4cf-c9a50fec837b"),
                            AvailableCapacity = 5000,
                            IsAvailable = true,
                            MaxCapacity = 5000,
                            Name = "Taylor",
                            PerformanceDateTime = new DateTime(2023, 6, 11, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7545),
                            Price = 100.0
                        },
                        new
                        {
                            Id = new Guid("61911d89-e99e-444c-b464-1cf01655d5c3"),
                            AvailableCapacity = 1000,
                            IsAvailable = true,
                            MaxCapacity = 1000,
                            Name = "Eminem",
                            PerformanceDateTime = new DateTime(2023, 6, 6, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7576),
                            Price = 70.0
                        },
                        new
                        {
                            Id = new Guid("dd6b66d3-2871-4fc5-9650-3abd2d356dd2"),
                            AvailableCapacity = 500,
                            IsAvailable = true,
                            MaxCapacity = 500,
                            Name = "Ariande",
                            PerformanceDateTime = new DateTime(2023, 6, 4, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7579),
                            Price = 50.0
                        },
                        new
                        {
                            Id = new Guid("749924b4-52db-42f1-8eaa-39d177e819a3"),
                            AvailableCapacity = 500,
                            IsAvailable = true,
                            MaxCapacity = 500,
                            Name = "Arjit",
                            PerformanceDateTime = new DateTime(2023, 6, 16, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7582),
                            Price = 80.0
                        });
                });

            modelBuilder.Entity("Kiosk.DAL.DBModels.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountPaid")
                        .HasColumnType("float");

                    b.Property<Guid>("ConcertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Kiosk.DAL.DBModels.Reservation", b =>
                {
                    b.HasOne("Kiosk.DAL.DBModels.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");
                });
#pragma warning restore 612, 618
        }
    }
}

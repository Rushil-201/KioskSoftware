using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kiosk.DAL.Migrations
{
    /// <inheritdoc />
    public partial class KioskSoftwareV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    PerformanceDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableCapacity = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                    table.CheckConstraint("check_Availability_constraint", "[AvailableCapacity] >= 0");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Concert",
                columns: new[] { "Id", "AvailableCapacity", "IsAvailable", "MaxCapacity", "Name", "PerformanceDateTime", "Price" },
                values: new object[,]
                {
                    { new Guid("61911d89-e99e-444c-b464-1cf01655d5c3"), 1000, true, 1000, "Eminem", new DateTime(2023, 6, 6, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7576), 70.0 },
                    { new Guid("749924b4-52db-42f1-8eaa-39d177e819a3"), 500, true, 500, "Arjit", new DateTime(2023, 6, 16, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7582), 80.0 },
                    { new Guid("a07d385e-a8db-44a5-a4cf-c9a50fec837b"), 5000, true, 5000, "Taylor", new DateTime(2023, 6, 11, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7545), 100.0 },
                    { new Guid("dd6b66d3-2871-4fc5-9650-3abd2d356dd2"), 500, true, 500, "Ariande", new DateTime(2023, 6, 4, 3, 14, 12, 302, DateTimeKind.Local).AddTicks(7579), 50.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ConcertId",
                table: "Reservation",
                column: "ConcertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Concert");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAttendingToGuestBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAttending",
                table: "Guests");

            migrationBuilder.AddColumn<bool>(
                name: "IsAttending",
                table: "GuestBookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 1, 12, 15, 1, 53, 832, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 2, 12, 15, 1, 53, 832, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "GuestBookings",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 1, 1 },
                column: "IsAttending",
                value: true);

            migrationBuilder.UpdateData(
                table: "GuestBookings",
                keyColumns: new[] { "EventId", "GuestId" },
                keyValues: new object[] { 1, 2 },
                column: "IsAttending",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAttending",
                table: "GuestBookings");

            migrationBuilder.AddColumn<bool>(
                name: "IsAttending",
                table: "Guests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 28, 14, 35, 5, 420, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 1, 28, 14, 35, 5, 420, DateTimeKind.Local).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAttending",
                value: true);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAttending",
                value: false);
        }
    }
}

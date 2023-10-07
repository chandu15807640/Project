using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LindnerAirlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class app4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "DepartureDateTime",
                table: "Flight",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "ArrivalDateTime",
                table: "Flight",
                newName: "Destination");

            migrationBuilder.RenameColumn(
                name: "SeatNumber",
                table: "Booking",
                newName: "Source");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Booking",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CabinClass",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssistType",
                table: "Assist",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CabinClass",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "AssistType",
                table: "Assist");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Flight",
                newName: "DepartureDateTime");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Flight",
                newName: "ArrivalDateTime");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Booking",
                newName: "SeatNumber");
        }
    }
}

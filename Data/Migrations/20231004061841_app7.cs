using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LindnerAirlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class app7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CabinClass",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "SeatClass",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatClass",
                table: "Booking");

            migrationBuilder.AddColumn<string>(
                name: "CabinClass",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

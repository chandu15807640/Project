using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LindnerAirlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class app5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PNR",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PNR",
                table: "Booking");
        }
    }
}

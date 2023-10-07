using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LindnerAirlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class app1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Flight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "Flight",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

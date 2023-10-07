using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LindnerAirlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class app2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assist_User_UserId",
                table: "Assist");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Flight_FlightId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Booking",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Assist",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Assist_User_UserId",
                table: "Assist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Flight_FlightId",
                table: "Booking",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assist_User_UserId",
                table: "Assist");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Flight_FlightId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Assist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assist_User_UserId",
                table: "Assist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Flight_FlightId",
                table: "Booking",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

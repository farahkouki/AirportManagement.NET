using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flights_FlightFk",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passengers_passengerFk",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_passengerFk",
                table: "Tickets",
                newName: "IX_Tickets_passengerFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                columns: new[] { "FlightFk", "passengerFk" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightFk",
                table: "Tickets",
                column: "FlightFk",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_passengerFk",
                table: "Tickets",
                column: "passengerFk",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightFk",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_passengerFk",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_passengerFk",
                table: "Ticket",
                newName: "IX_Ticket_passengerFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                columns: new[] { "FlightFk", "passengerFk" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flights_FlightFk",
                table: "Ticket",
                column: "FlightFk",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passengers_passengerFk",
                table: "Ticket",
                column: "passengerFk",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

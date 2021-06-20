using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketUser",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SubTicket");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SubTicket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SubTicket");

            migrationBuilder.AddColumn<string>(
                name: "TicketUser",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SubTicket",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

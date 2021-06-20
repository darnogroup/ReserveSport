using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _5353 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SubTicket_UserId",
                table: "SubTicket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTicket_User_UserId",
                table: "SubTicket",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTicket_User_UserId",
                table: "SubTicket");

            migrationBuilder.DropIndex(
                name: "IX_SubTicket_UserId",
                table: "SubTicket");
        }
    }
}

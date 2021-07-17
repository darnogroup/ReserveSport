using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changeBools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finish",
                table: "Reserve");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "ReserveSportsModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "ReserveSportsModels");

            migrationBuilder.AddColumn<bool>(
                name: "Finish",
                table: "Reserve",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

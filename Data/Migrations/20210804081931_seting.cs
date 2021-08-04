using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageOne",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThree",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTwo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageOne",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ImageThree",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ImageTwo",
                table: "Setting");
        }
    }
}

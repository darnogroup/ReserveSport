using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Ne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutModels",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutSlogan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutModels", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "AdsModels",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BannerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdsModels", x => x.BannerId);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintModels",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintUserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ComplaintPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ComplaintDescription = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintModels", x => x.ComplaintId);
                });

            migrationBuilder.CreateTable(
                name: "ContactModels",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactBody = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactModels", x => x.ContactId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutModels");

            migrationBuilder.DropTable(
                name: "AdsModels");

            migrationBuilder.DropTable(
                name: "ComplaintModels");

            migrationBuilder.DropTable(
                name: "ContactModels");
        }
    }
}

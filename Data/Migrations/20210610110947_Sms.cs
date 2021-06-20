using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Sms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Reserve",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SmsAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsGeneral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsGeneral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsRemember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsRemember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsThank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThankText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsThank", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmsAdmin");

            migrationBuilder.DropTable(
                name: "SmsCustomer");

            migrationBuilder.DropTable(
                name: "SmsGeneral");

            migrationBuilder.DropTable(
                name: "SmsRemember");

            migrationBuilder.DropTable(
                name: "SmsThank");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Reserve");
        }
    }
}

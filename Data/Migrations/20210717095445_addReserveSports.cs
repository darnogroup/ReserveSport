using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addReserveSports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "Reserve");

            migrationBuilder.CreateTable(
                name: "ReserveSportsModels",
                columns: table => new
                {
                    ReserveSportsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserveId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveSportsModels", x => x.ReserveSportsId);
                    table.ForeignKey(
                        name: "FK_ReserveSportsModels_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserve",
                        principalColumn: "ReserveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveSportsModels_ReserveId",
                table: "ReserveSportsModels",
                column: "ReserveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveSportsModels");

            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "Reserve",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

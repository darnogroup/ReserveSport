using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Bank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financial",
                columns: table => new
                {
                    FinancialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialSheba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financial", x => x.FinancialId);
                    table.ForeignKey(
                        name: "FK_Financial_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financial_CollectionId",
                table: "Financial",
                column: "CollectionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financial");
        }
    }
}

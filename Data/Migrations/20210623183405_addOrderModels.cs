using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addOrderModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderModels",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinally = table.Column<bool>(type: "bit", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModels", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderModels_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailModels",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Close = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ReserveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailModels", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetailModels_OrderModels_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderModels",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetailModels_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserve",
                        principalColumn: "ReserveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailModels_OrderId",
                table: "OrderDetailModels",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailModels_ReserveId",
                table: "OrderDetailModels",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModels_UserId",
                table: "OrderModels",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailModels");

            migrationBuilder.DropTable(
                name: "OrderModels");
        }
    }
}

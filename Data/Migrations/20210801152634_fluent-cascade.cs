using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fluentcascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banner_Collection_CollectionId",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Collection_CollectionId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailModels_OrderModels_OrderId",
                table: "OrderDetailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailModels_Reserve_ReserveId",
                table: "OrderDetailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveSportsModels_Reserve_ReserveId",
                table: "ReserveSportsModels");

            migrationBuilder.DropForeignKey(
                name: "FK_SportCollection_Collection_CollectionId",
                table: "SportCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_SportCollection_Sport_SportId",
                table: "SportCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTicket_Ticket_TicketId",
                table: "SubTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTicket_User_UserId",
                table: "SubTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWallet_User_UserId",
                table: "UserWallet");

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_Collection_CollectionId",
                table: "Banner",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Collection_CollectionId",
                table: "Financial",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailModels_OrderModels_OrderId",
                table: "OrderDetailModels",
                column: "OrderId",
                principalTable: "OrderModels",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailModels_Reserve_ReserveId",
                table: "OrderDetailModels",
                column: "ReserveId",
                principalTable: "Reserve",
                principalColumn: "ReserveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveSportsModels_Reserve_ReserveId",
                table: "ReserveSportsModels",
                column: "ReserveId",
                principalTable: "Reserve",
                principalColumn: "ReserveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportCollection_Collection_CollectionId",
                table: "SportCollection",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportCollection_Sport_SportId",
                table: "SportCollection",
                column: "SportId",
                principalTable: "Sport",
                principalColumn: "SportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTicket_Ticket_TicketId",
                table: "SubTicket",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTicket_User_UserId",
                table: "SubTicket",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWallet_User_UserId",
                table: "UserWallet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banner_Collection_CollectionId",
                table: "Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Collection_CollectionId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailModels_OrderModels_OrderId",
                table: "OrderDetailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailModels_Reserve_ReserveId",
                table: "OrderDetailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveSportsModels_Reserve_ReserveId",
                table: "ReserveSportsModels");

            migrationBuilder.DropForeignKey(
                name: "FK_SportCollection_Collection_CollectionId",
                table: "SportCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_SportCollection_Sport_SportId",
                table: "SportCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTicket_Ticket_TicketId",
                table: "SubTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTicket_User_UserId",
                table: "SubTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWallet_User_UserId",
                table: "UserWallet");

            migrationBuilder.AddForeignKey(
                name: "FK_Banner_Collection_CollectionId",
                table: "Banner",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Collection_CollectionId",
                table: "Financial",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailModels_OrderModels_OrderId",
                table: "OrderDetailModels",
                column: "OrderId",
                principalTable: "OrderModels",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailModels_Reserve_ReserveId",
                table: "OrderDetailModels",
                column: "ReserveId",
                principalTable: "Reserve",
                principalColumn: "ReserveId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveSportsModels_Reserve_ReserveId",
                table: "ReserveSportsModels",
                column: "ReserveId",
                principalTable: "Reserve",
                principalColumn: "ReserveId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportCollection_Collection_CollectionId",
                table: "SportCollection",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportCollection_Sport_SportId",
                table: "SportCollection",
                column: "SportId",
                principalTable: "Sport",
                principalColumn: "SportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTicket_Ticket_TicketId",
                table: "SubTicket",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTicket_User_UserId",
                table: "SubTicket",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWallet_User_UserId",
                table: "UserWallet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

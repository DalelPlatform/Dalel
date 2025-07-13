using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceQuaries_Chats_ChatId",
                table: "ServiceQuaries");


            migrationBuilder.AddColumn<int>(
                name: "ServiceChatId",
                table: "ServiceQuaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuaries_ServiceChatId",
                table: "ServiceQuaries",
                column: "ServiceChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceQuaries_Chats_ServiceChatId",
                table: "ServiceQuaries",
                column: "ServiceChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceQuaries_Chats_ServiceChatId",
                table: "ServiceQuaries");

            migrationBuilder.DropIndex(
                name: "IX_ServiceQuaries_ServiceChatId",
                table: "ServiceQuaries");

            migrationBuilder.DropColumn(
                name: "ServiceChatId",
                table: "ServiceQuaries");

            //migrationBuilder.AddColumn<int>(
            //    name: "ChatId",
            //    table: "ServiceQuaries",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ServiceQuaries_Chats_ChatId",
            //    table: "ServiceQuaries",
            //    column: "ChatId",
            //    principalTable: "Chats",
            //    principalColumn: "Id");
        }
    }
}

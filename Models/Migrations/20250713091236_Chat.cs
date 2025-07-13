using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "ServiceProviderProjects",
                newName: "Image");

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "ServiceQuaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ServiceQuaries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastMessageAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Chats_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuaries_ChatId",
                table: "ServiceQuaries",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ClientId",
                table: "Chats",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ServiceProviderId",
                table: "Chats",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceQuaries_Chats_ChatId",
                table: "ServiceQuaries",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceQuaries_Chats_ChatId",
                table: "ServiceQuaries");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_ServiceQuaries_ChatId",
                table: "ServiceQuaries");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "ServiceQuaries");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ServiceQuaries");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ServiceProviderProjects",
                newName: "VideoLink");

            migrationBuilder.CreateTable(
                name: "ServiceProviderProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderProjectId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderProjectImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderProjectImages_ServiceProviderProjects_ServiceProviderProjectId",
                        column: x => x.ServiceProviderProjectId,
                        principalTable: "ServiceProviderProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderProjectImages_ServiceProviderProjectId",
                table: "ServiceProviderProjectImages",
                column: "ServiceProviderProjectId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class restaurantUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "RestaurantMenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RestaurantCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupPrice = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantMenuItemId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantCartItems_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCartItems_RestaurantMenuItems_RestaurantMenuItemId",
                        column: x => x.RestaurantMenuItemId,
                        principalTable: "RestaurantMenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ServiceRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesNotifications_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesNotifications_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesNotifications_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCartItems_ClientId",
                table: "RestaurantCartItems",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCartItems_RestaurantMenuItemId",
                table: "RestaurantCartItems",
                column: "RestaurantMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesNotifications_ClientId",
                table: "ServicesNotifications",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesNotifications_ServiceProviderId",
                table: "ServicesNotifications",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesNotifications_ServiceRequestId",
                table: "ServicesNotifications",
                column: "ServiceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantCartItems");

            migrationBuilder.DropTable(
                name: "ServicesNotifications");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "RestaurantMenuItems");
        }
    }
}

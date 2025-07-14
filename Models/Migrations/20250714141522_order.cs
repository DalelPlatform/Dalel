using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOrders_Restaurants_RestaurantId",
                table: "RestaurantOrders");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrders_RestaurantId",
                table: "RestaurantOrders");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrders_RestaurantId",
                table: "RestaurantOrders",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOrders_Restaurants_RestaurantId",
                table: "RestaurantOrders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}

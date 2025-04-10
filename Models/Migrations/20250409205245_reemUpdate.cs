using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class reemUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMenuItemImages_RestaurantMenuItems_RestaurantMenuItemId",
                table: "RestaurantMenuItemImages");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "ReviewHotelRooms",
                newName: "ReviewDate");

            migrationBuilder.AddColumn<bool>(
                name: "HasBreakfast",
                table: "RoomTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxOccupancy",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Availability",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "BookingHotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_City",
                table: "Hotels",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_VerificationStatus",
                table: "Hotels",
                column: "VerificationStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMenuItemImages_RestaurantMenuItems_RestaurantMenuItemId",
                table: "RestaurantMenuItemImages",
                column: "RestaurantMenuItemId",
                principalTable: "RestaurantMenuItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMenuItemImages_RestaurantMenuItems_RestaurantMenuItemId",
                table: "RestaurantMenuItemImages");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_City",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_VerificationStatus",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HasBreakfast",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "MaxOccupancy",
                table: "RoomTypes");

            migrationBuilder.RenameColumn(
                name: "ReviewDate",
                table: "ReviewHotelRooms",
                newName: "ModificationDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "Availability",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "BookingHotelRooms",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMenuItemImages_RestaurantMenuItems_RestaurantMenuItemId",
                table: "RestaurantMenuItemImages",
                column: "RestaurantMenuItemId",
                principalTable: "RestaurantMenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class AbouZaiderror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "AccessibilityFeatures",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "BedType",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "BookingHotelRooms");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "BookingGuestsInRooms");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ReviewHotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClientUserId",
                table: "ReviewHotelRooms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantReservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ClientUserId",
                table: "PaymentHotelRooms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHotelRooms_ClientUserId",
                table: "ReviewHotelRooms",
                column: "ClientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHotelRooms_ClientUserId",
                table: "PaymentHotelRooms",
                column: "ClientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHotelRooms_HotelId",
                table: "PaymentHotelRooms",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHotelRooms_Client_ClientUserId",
                table: "PaymentHotelRooms",
                column: "ClientUserId",
                principalTable: "Client",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHotelRooms_Hotels_HotelId",
                table: "PaymentHotelRooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewHotelRooms_Client_ClientUserId",
                table: "ReviewHotelRooms",
                column: "ClientUserId",
                principalTable: "Client",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHotelRooms_Client_ClientUserId",
                table: "PaymentHotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHotelRooms_Hotels_HotelId",
                table: "PaymentHotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewHotelRooms_Client_ClientUserId",
                table: "ReviewHotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_ReviewHotelRooms_ClientUserId",
                table: "ReviewHotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHotelRooms_ClientUserId",
                table: "PaymentHotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHotelRooms_HotelId",
                table: "PaymentHotelRooms");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ReviewHotelRooms");

            migrationBuilder.DropColumn(
                name: "ClientUserId",
                table: "ReviewHotelRooms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "ClientUserId",
                table: "PaymentHotelRooms");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Service",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Service",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Service",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Service",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessibilityFeatures",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BedType",
                table: "Rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                table: "Rooms",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "BookingHotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "BookingGuestsInRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingProperties_Client_ClientId",
                table: "BookingProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingProperties_Properties_PropertyId",
                table: "BookingProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingProperties_Client_ClientId",
                table: "BookingProperties",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingProperties_Properties_PropertyId",
                table: "BookingProperties",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingProperties_Client_ClientId",
                table: "BookingProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingProperties_Properties_PropertyId",
                table: "BookingProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingProperties_Client_ClientId",
                table: "BookingProperties",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingProperties_Properties_PropertyId",
                table: "BookingProperties",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

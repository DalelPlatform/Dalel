using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class update2HomeChef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeChefId",
                table: "ReviewHomeChefOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "HomeChefDeliveries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHomeChefOrders_HomeChefId",
                table: "ReviewHomeChefOrders",
                column: "HomeChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewHomeChefOrders_HomeChefs_HomeChefId",
                table: "ReviewHomeChefOrders",
                column: "HomeChefId",
                principalTable: "HomeChefs",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewHomeChefOrders_HomeChefs_HomeChefId",
                table: "ReviewHomeChefOrders");

            migrationBuilder.DropIndex(
                name: "IX_ReviewHomeChefOrders_HomeChefId",
                table: "ReviewHomeChefOrders");

            migrationBuilder.DropColumn(
                name: "HomeChefId",
                table: "ReviewHomeChefOrders");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "HomeChefDeliveries");
        }
    }
}

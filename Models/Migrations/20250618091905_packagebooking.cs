using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class packagebooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "PackageBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "PackageBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "PackageBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "AgencyPackages",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_PackageId",
                table: "PackageBookings",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageBookings_AgencyPackages_PackageId",
                table: "PackageBookings",
                column: "PackageId",
                principalTable: "AgencyPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageBookings_AgencyPackages_PackageId",
                table: "PackageBookings");

            migrationBuilder.DropIndex(
                name: "IX_PackageBookings_PackageId",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "PackageBookings");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "AgencyPackages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}

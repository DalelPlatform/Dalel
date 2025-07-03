using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class inttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "ServiceProviderReviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceProviderId",
                table: "ServiceProviderReviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderReviews_ClientId",
                table: "ServiceProviderReviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderReviews_ServiceProviderId",
                table: "ServiceProviderReviews",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderReviews_Client_ClientId",
                table: "ServiceProviderReviews",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderReviews_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderReviews",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderReviews_Client_ClientId",
                table: "ServiceProviderReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderReviews_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderReviews");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviderReviews_ClientId",
                table: "ServiceProviderReviews");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviderReviews_ServiceProviderId",
                table: "ServiceProviderReviews");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ServiceProviderReviews");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                table: "ServiceProviderReviews");
        }
    }
}

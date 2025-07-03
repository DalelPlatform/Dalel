using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class reem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "Licence",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "VerificationStatus",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "ProjectImages",
                table: "ServiceProviderProjects");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "ServiceProviders",
                newName: "Website");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ServiceProviders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "ServiceProviders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ServiceProviders",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceUnit",
                table: "ServiceProviders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceArea",
                table: "ServiceProviders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "ServiceProviders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ServiceProviderProjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<decimal>(
                name: "ApproximatePrice",
                table: "ServiceProviderProjects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PriceUnit",
                table: "ServiceProviderProjects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "ServiceProviderProjects",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "District",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "PriceUnit",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "ServiceArea",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "ApproximatePrice",
                table: "ServiceProviderProjects");

            migrationBuilder.DropColumn(
                name: "PriceUnit",
                table: "ServiceProviderProjects");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "ServiceProviderProjects");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "ServiceProviders",
                newName: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "ServiceProviders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Licence",
                table: "ServiceProviders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VerificationStatus",
                table: "ServiceProviders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ServiceProviderProjects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ProjectImages",
                table: "ServiceProviderProjects",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}

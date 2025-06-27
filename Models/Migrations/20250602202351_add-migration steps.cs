using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationsteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageSteps_AgencyPackages_AgencyPackageId",
                table: "PackageSteps");

            migrationBuilder.DropIndex(
                name: "IX_PackageSteps_AgencyPackageId",
                table: "PackageSteps");

            migrationBuilder.DropColumn(
                name: "AgencyPackageId",
                table: "PackageSteps");

            migrationBuilder.CreateIndex(
                name: "IX_PackageSteps_PackageId",
                table: "PackageSteps",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageSteps_AgencyPackages_PackageId",
                table: "PackageSteps",
                column: "PackageId",
                principalTable: "AgencyPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageSteps_AgencyPackages_PackageId",
                table: "PackageSteps");

            migrationBuilder.DropIndex(
                name: "IX_PackageSteps_PackageId",
                table: "PackageSteps");

            migrationBuilder.AddColumn<int>(
                name: "AgencyPackageId",
                table: "PackageSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PackageSteps_AgencyPackageId",
                table: "PackageSteps",
                column: "AgencyPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageSteps_AgencyPackages_AgencyPackageId",
                table: "PackageSteps",
                column: "AgencyPackageId",
                principalTable: "AgencyPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

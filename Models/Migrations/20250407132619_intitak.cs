using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class intitak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderProjects_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderProjects");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ServiceProviderProjects",
                newName: "ProjectImages");

            migrationBuilder.CreateTable(
                name: "ServiceProviderProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceProviderProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderProjectImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderProjectImages_ServiceProviderProjects_ServiceProviderProjectId",
                        column: x => x.ServiceProviderProjectId,
                        principalTable: "ServiceProviderProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderProjectImages_ServiceProviderProjectId",
                table: "ServiceProviderProjectImages",
                column: "ServiceProviderProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderProjects_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderProjects",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderProjects_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderProjects");

            migrationBuilder.DropTable(
                name: "ServiceProviderProjectImages");

            migrationBuilder.RenameColumn(
                name: "ProjectImages",
                table: "ServiceProviderProjects",
                newName: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderProjects_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderProjects",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "UserId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class removeProjectImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceProviderProjectImages");

            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "ServiceProviderProjects",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ServiceProviderProjects",
                newName: "VideoLink");

            migrationBuilder.CreateTable(
                name: "ServiceProviderProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderProjectId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
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
        }
    }
}

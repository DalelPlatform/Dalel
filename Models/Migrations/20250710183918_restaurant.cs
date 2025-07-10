using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class restaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "NVARCHAR(20000)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RestaurantMenuItems",
                type: "NVARCHAR(20000)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldDefaultValue: "empty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "NVARCHAR(250)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20000)",
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RestaurantMenuItems",
                type: "NVARCHAR(250)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20000)",
                oldDefaultValue: "empty");
        }
    }
}

using System;
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
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImg",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: true,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<string>(
                name: "ModificationBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: true,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: true,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: true,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldDefaultValue: "empty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImg",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldNullable: true,
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<string>(
                name: "ModificationBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldNullable: true,
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldNullable: true,
                oldDefaultValue: "empty");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "empty",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldNullable: true,
                oldDefaultValue: "empty");
        }
    }
}

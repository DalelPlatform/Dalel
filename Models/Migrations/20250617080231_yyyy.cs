using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class yyyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "ServiceQuaries");

            migrationBuilder.DropColumn(
                name: "AnswerDate",
                table: "ServiceQuaries");

            migrationBuilder.RenameColumn(
                name: "QuestionDate",
                table: "ServiceQuaries",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "ServiceQuaries",
                newName: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "ServiceProviderName",
                table: "ServiceProviderPropsals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceProviderName",
                table: "ServiceProviderPropsals");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "ServiceQuaries",
                newName: "QuestionDate");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "ServiceQuaries",
                newName: "Question");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "ServiceQuaries",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnswerDate",
                table: "ServiceQuaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

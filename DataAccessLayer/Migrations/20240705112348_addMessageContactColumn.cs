using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addMessageContactColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_Message",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedDescription",
                table: "ContactTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedTitle",
                table: "ContactTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_Message",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TranslatedDescription",
                table: "ContactTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedTitle",
                table: "ContactTranslations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contacts");
        }
    }
}

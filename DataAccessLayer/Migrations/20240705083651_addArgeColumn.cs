using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addArgeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TranslatedDescription3",
                table: "ArgeTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedDescription4",
                table: "ArgeTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedName2",
                table: "ArgeTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "Arges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description4",
                table: "Arges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name2",
                table: "Arges",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranslatedDescription3",
                table: "ArgeTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedDescription4",
                table: "ArgeTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedName2",
                table: "ArgeTranslations");

            migrationBuilder.DropColumn(
                name: "Description3",
                table: "Arges");

            migrationBuilder.DropColumn(
                name: "Description4",
                table: "Arges");

            migrationBuilder.DropColumn(
                name: "Name2",
                table: "Arges");
        }
    }
}

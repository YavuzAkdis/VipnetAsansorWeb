using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addProductDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TranslatedDescription2",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedDescription3",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedDescription4",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedPImageUrl",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedPdfFileImage",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedPdfFileName",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranslatedPdfFileUrl",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desciption2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desciption3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desciption4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranslatedDescription2",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedDescription3",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedDescription4",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedPImageUrl",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedPdfFileImage",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedPdfFileName",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "TranslatedPdfFileUrl",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "Desciption2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Desciption3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Desciption4",
                table: "Products");
        }
    }
}

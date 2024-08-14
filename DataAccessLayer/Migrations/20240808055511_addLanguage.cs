using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "MasterBrands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Headers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Arges",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "MasterBrands");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Arges");
        }
    }
}

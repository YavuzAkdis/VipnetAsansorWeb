using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addTopbarColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Topbars",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Topbars",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Topbars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Topbars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Topbars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Topbars");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Topbars",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Topbars",
                newName: "Mail");
        }
    }
}

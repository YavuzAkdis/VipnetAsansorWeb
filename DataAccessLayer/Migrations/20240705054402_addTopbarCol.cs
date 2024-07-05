using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addTopbarCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Topbars");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Topbars",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Topbars",
                newName: "LogoUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Topbars",
                newName: "LinkUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Topbars",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Topbars",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Topbars",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "LinkUrl",
                table: "Topbars",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Topbars",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Topbars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

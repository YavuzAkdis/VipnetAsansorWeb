using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_Gallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalleryID",
                table: "ArgeTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    GalleryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.GalleryID);
                });

            migrationBuilder.CreateTable(
                name: "GalleryTranslations",
                columns: table => new
                {
                    GalleryTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryTranslations", x => x.GalleryTranslationID);
                    table.ForeignKey(
                        name: "FK_GalleryTranslations_Galleries_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "Galleries",
                        principalColumn: "GalleryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArgeTranslations_GalleryID",
                table: "ArgeTranslations",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryTranslations_GalleryID",
                table: "GalleryTranslations",
                column: "GalleryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArgeTranslations_Galleries_GalleryID",
                table: "ArgeTranslations",
                column: "GalleryID",
                principalTable: "Galleries",
                principalColumn: "GalleryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArgeTranslations_Galleries_GalleryID",
                table: "ArgeTranslations");

            migrationBuilder.DropTable(
                name: "GalleryTranslations");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_ArgeTranslations_GalleryID",
                table: "ArgeTranslations");

            migrationBuilder.DropColumn(
                name: "GalleryID",
                table: "ArgeTranslations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addDeleteTranstions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutTranslations");

            migrationBuilder.DropTable(
                name: "ArgeTranslations");

            migrationBuilder.DropTable(
                name: "BrandTranslations");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "ContactTranslations");

            migrationBuilder.DropTable(
                name: "FeatureTranslations");

            migrationBuilder.DropTable(
                name: "GalleryTranslations");

            migrationBuilder.DropTable(
                name: "HeaderTranslations");

            migrationBuilder.DropTable(
                name: "MasterBrandTranslations");

            migrationBuilder.DropTable(
                name: "PortfolioTranslation");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "QuestionTranslations");

            migrationBuilder.DropTable(
                name: "SkillTranslations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutTranslations",
                columns: table => new
                {
                    AboutTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutTranslations", x => x.AboutTranslationID);
                    table.ForeignKey(
                        name: "FK_AboutTranslations_Abouts_AboutID",
                        column: x => x.AboutID,
                        principalTable: "Abouts",
                        principalColumn: "AboutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArgeTranslations",
                columns: table => new
                {
                    ArgeTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArgeID = table.Column<int>(type: "int", nullable: false),
                    GalleryID = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArgeTranslations", x => x.ArgeTranslationID);
                    table.ForeignKey(
                        name: "FK_ArgeTranslations_Arges_ArgeID",
                        column: x => x.ArgeID,
                        principalTable: "Arges",
                        principalColumn: "ArgeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArgeTranslations_Galleries_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "Galleries",
                        principalColumn: "GalleryID");
                });

            migrationBuilder.CreateTable(
                name: "BrandTranslations",
                columns: table => new
                {
                    BrandTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTranslations", x => x.BrandTranslationID);
                    table.ForeignKey(
                        name: "FK_BrandTranslations_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    CategoryTranslationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.CategoryTranslationId);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactTranslations",
                columns: table => new
                {
                    ContactTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedMaps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTranslations", x => x.ContactTranslationID);
                    table.ForeignKey(
                        name: "FK_ContactTranslations_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureTranslations",
                columns: table => new
                {
                    FeatureTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDesciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureTranslations", x => x.FeatureTranslationID);
                    table.ForeignKey(
                        name: "FK_FeatureTranslations_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "FeatureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryTranslations",
                columns: table => new
                {
                    GalleryTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "HeaderTranslations",
                columns: table => new
                {
                    HeaderTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedP1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedP2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedP3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedP4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderTranslations", x => x.HeaderTranslationID);
                    table.ForeignKey(
                        name: "FK_HeaderTranslations_Headers_HeaderID",
                        column: x => x.HeaderID,
                        principalTable: "Headers",
                        principalColumn: "HeaderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterBrandTranslations",
                columns: table => new
                {
                    MasterBrandTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterBrandID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterBrandTranslations", x => x.MasterBrandTranslationID);
                    table.ForeignKey(
                        name: "FK_MasterBrandTranslations_MasterBrands_MasterBrandID",
                        column: x => x.MasterBrandID,
                        principalTable: "MasterBrands",
                        principalColumn: "MasterBrandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioTranslation",
                columns: table => new
                {
                    PortfolioTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedP1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedP2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedP3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedSP1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedSP2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioTranslation", x => x.PortfolioTranslationID);
                    table.ForeignKey(
                        name: "FK_PortfolioTranslation_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    ProductTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedIsApproved = table.Column<bool>(type: "bit", nullable: true),
                    TranslatedIsHome = table.Column<bool>(type: "bit", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedPImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedPdfFileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedPdfFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedPdfFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.ProductTranslationID);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTranslations",
                columns: table => new
                {
                    QuestionTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTranslations", x => x.QuestionTranslationID);
                    table.ForeignKey(
                        name: "FK_QuestionTranslations_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillTranslations",
                columns: table => new
                {
                    SkillTranslationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTranslations", x => x.SkillTranslationID);
                    table.ForeignKey(
                        name: "FK_SkillTranslations_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutTranslations_AboutID",
                table: "AboutTranslations",
                column: "AboutID");

            migrationBuilder.CreateIndex(
                name: "IX_ArgeTranslations_ArgeID",
                table: "ArgeTranslations",
                column: "ArgeID");

            migrationBuilder.CreateIndex(
                name: "IX_ArgeTranslations_GalleryID",
                table: "ArgeTranslations",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_BrandID",
                table: "BrandTranslations",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTranslations_ContactID",
                table: "ContactTranslations",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureTranslations_FeatureID",
                table: "FeatureTranslations",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryTranslations_GalleryID",
                table: "GalleryTranslations",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderTranslations_HeaderID",
                table: "HeaderTranslations",
                column: "HeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterBrandTranslations_MasterBrandID",
                table: "MasterBrandTranslations",
                column: "MasterBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioTranslation_PortfolioID",
                table: "PortfolioTranslation",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductID",
                table: "ProductTranslations",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTranslations_QuestionID",
                table: "QuestionTranslations",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTranslations_SkillID",
                table: "SkillTranslations",
                column: "SkillID");
        }
    }
}

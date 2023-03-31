using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMVCUyg.Data.Migrations
{
    public partial class allmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Host = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Port = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GetDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Messages = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    GetDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMainCategory",
                columns: table => new
                {
                    ProductMainCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductMainCategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMainCategory", x => x.ProductMainCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unvan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CalismaSaat = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Adres2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Telefon2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GooglePlus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleMapLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkimizdaFooterAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Designer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContentLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Robots = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Charset = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Distribution = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Copyright = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Abstract = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Raiting = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubCategory",
                columns: table => new
                {
                    ProductSubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSubCategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ProductMainCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubCategory", x => x.ProductSubCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductSubCategory_ProductMainCategory_ProductMainCategoryId",
                        column: x => x.ProductMainCategoryId,
                        principalTable: "ProductMainCategory",
                        principalColumn: "ProductMainCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ProductMainCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductSubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductMainCategory_ProductMainCategoryId",
                        column: x => x.ProductMainCategoryId,
                        principalTable: "ProductMainCategory",
                        principalColumn: "ProductMainCategoryId");
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductSubCategory_ProductSubCategoryId",
                        column: x => x.ProductSubCategoryId,
                        principalTable: "ProductSubCategory",
                        principalColumn: "ProductSubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAd = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisaAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vitrin = table.Column<bool>(type: "bit", nullable: false),
                    ProductMainCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.UrunID);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryId");
                    table.ForeignKey(
                        name: "FK_Product_ProductMainCategory_ProductMainCategoryId",
                        column: x => x.ProductMainCategoryId,
                        principalTable: "ProductMainCategory",
                        principalColumn: "ProductMainCategoryId");
                    table.ForeignKey(
                        name: "FK_Product_ProductSubCategory_ProductSubCategoryId",
                        column: x => x.ProductSubCategoryId,
                        principalTable: "ProductSubCategory",
                        principalColumn: "ProductSubCategoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductMainCategoryId",
                table: "Product",
                column: "ProductMainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSubCategoryId",
                table: "Product",
                column: "ProductSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductMainCategoryId",
                table: "ProductCategory",
                column: "ProductMainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductSubCategoryId",
                table: "ProductCategory",
                column: "ProductSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubCategory_ProductMainCategoryId",
                table: "ProductSubCategory",
                column: "ProductMainCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "WebsiteInfo");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductSubCategory");

            migrationBuilder.DropTable(
                name: "ProductMainCategory");
        }
    }
}

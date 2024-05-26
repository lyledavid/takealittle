using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Takealittle.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "123456789AAA", null, null, "6 x 700ml", null, null, "All Gold Tomato Sauce", 209.0 },
                    { 2, "123456789AAB", null, null, "6 x 300ml cans", null, null, "Pepsi Max", 179.0 },
                    { 3, "123456789AAE", null, null, "Giga Jumbo Pack", null, null, "Huggies Nappies", 439.0 },
                    { 4, "123456789AAC", null, null, "1.1kg", null, null, "Mrs Balls Chutney", 69.0 },
                    { 5, "123456789AAD", null, null, "1.35kg", null, null, "Weetbix Cereal", 95.0 },
                    { 6, "123456789AAF", null, null, "6 x 750ml", null, null, "Energade Sports Drink", 179.0 },
                    { 7, "123456789AAG", null, null, "6 x 800g", null, null, "Black Cat Peanut Butter", 439.0 },
                    { 8, "123456789AAH", null, null, "12 x 1L", null, null, "Cooking Olive Oil", 1800.0 },
                    { 9, "123456789AAI", null, null, "4 x 5L", null, null, "Aqualle Natural Spring Water", 87.0 },
                    { 10, "123456789AAJ", null, null, "3kg", null, null, "Fatti's & Moni's Spaghetti", 159.0 },
                    { 11, "123456789AAK", null, null, "24 x 50g", null, null, "Beacon Jelly Tots", 299.0 },
                    { 12, "123456789AAL", null, null, "1.5kg", null, null, "Crosse & Blackwell Mayonnaise", 89.0 },
                    { 13, "123456789AAM", null, null, "1kg", null, null, "Almonds Raw", 204.0 },
                    { 14, "123456789AAN", null, null, "14 x 38g", null, null, "Skittles", 149.0 },
                    { 15, "123456789AAO", null, null, "10kg", null, null, "ACE Super Maize Meal", 189.0 },
                    { 16, "123456789AAP", null, null, "12 x 410g", null, null, "KOO Chakalaka", 269.0 },
                    { 17, "123456789AAQ", null, null, "10 x 75g", null, null, "Aromat Refill", 119.0 },
                    { 18, "123456789AAR", null, null, "24 x 400g", null, null, "Canned Chopped Tomatoes", 599.0 },
                    { 19, "123456789AAS", null, null, "24 x 400g", null, null, "Chickpeas in Brine", 269.0 },
                    { 20, "123456789AAT", null, null, "24 x 300ml", null, null, "Oros Mango", 199.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

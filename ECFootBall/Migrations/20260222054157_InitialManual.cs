using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECFootBall.Migrations
{
    /// <inheritdoc />
    public partial class InitialManual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePromotion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    AmountReview = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryLinks",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryLinks", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryLinks_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryLinks_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SizeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Description", "DisplayOrder", "IsActive", "IsDelete", "Name", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, "Nike", null, null },
                    { 2, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Adidas", null, null },
                    { 3, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, false, "Joma", null, null },
                    { 4, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, true, false, "Mizuno", null, null },
                    { 5, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, true, false, "Puma", null, null },
                    { 6, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, true, false, "Asics", null, null }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreateBy", "CreateDate", "DisplayOrder", "IsActive", "IsDelete", "Name", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, "Đỏ", null, null },
                    { 2, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, false, "Xanh Lá", null, null },
                    { 3, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, false, "Đen", null, null },
                    { 4, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, false, "Trắng", null, null },
                    { 5, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, false, "Vàng", null, null },
                    { 6, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, true, false, "Xanh Dương", null, null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreateBy", "CreateDate", "DisplayOrder", "IsActive", "IsDelete", "Name", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, false, "38", null, null },
                    { 2, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, false, "39", null, null },
                    { 3, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, false, "40", null, null },
                    { 4, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, false, "41", null, null },
                    { 5, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, false, "42", null, null },
                    { 6, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, true, false, "43", null, null },
                    { 7, "admin", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, false, "44", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryLinks_ProductsId",
                table: "ProductCategoryLinks",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductCategoryLinks");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}

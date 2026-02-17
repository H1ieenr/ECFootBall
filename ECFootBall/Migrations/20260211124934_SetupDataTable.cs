using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECFootBall.Migrations
{
    /// <inheritdoc />
    public partial class SetupDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreateBy", "CreateDate", "DisplayOrder", "IsDelete", "Name", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, false, "Đỏ", null, null },
                    { 2, null, null, null, false, "Xanh Lá", null, null },
                    { 3, null, null, null, false, "Đen", null, null },
                    { 4, null, null, null, false, "Trắng", null, null },
                    { 5, null, null, null, false, "Vàng", null, null },
                    { 6, null, null, null, false, "Xanh Dương", null, null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreateBy", "CreateDate", "DisplayOrder", "IsDelete", "Name", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, false, "38", null, null },
                    { 2, null, null, null, false, "39", null, null },
                    { 3, null, null, null, false, "40", null, null },
                    { 4, null, null, null, false, "41", null, null },
                    { 5, null, null, null, false, "42", null, null },
                    { 6, null, null, null, false, "43", null, null },
                    { 7, null, null, null, false, "44", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}

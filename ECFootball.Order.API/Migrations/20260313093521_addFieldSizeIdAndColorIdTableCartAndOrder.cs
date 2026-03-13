using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECFootball.Order.API.Migrations
{
    /// <inheritdoc />
    public partial class addFieldSizeIdAndColorIdTableCartAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorId",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "CartItems");
        }
    }
}

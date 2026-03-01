using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECFootBall.Migrations
{
    /// <inheritdoc />
    public partial class addFieldIsPromotionTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPromotion",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPromotion",
                table: "Products");
        }
    }
}

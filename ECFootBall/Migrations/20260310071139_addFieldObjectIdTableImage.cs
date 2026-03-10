using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECFootBall.Migrations
{
    /// <inheritdoc />
    public partial class addFieldObjectIdTableImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObjectId",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "Images");
        }
    }
}

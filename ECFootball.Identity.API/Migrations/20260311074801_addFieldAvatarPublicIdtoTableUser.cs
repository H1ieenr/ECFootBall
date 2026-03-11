using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECFootball.Identity.API.Migrations
{
    /// <inheritdoc />
    public partial class addFieldAvatarPublicIdtoTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPublicId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPublicId",
                table: "Users");
        }
    }
}

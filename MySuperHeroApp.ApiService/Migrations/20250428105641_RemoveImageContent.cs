using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySuperHeroApp.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContent",
                table: "SuperHeroes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageContent",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

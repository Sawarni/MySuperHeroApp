using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySuperHeroApp.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class AliasHeighWeightChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");

            migrationBuilder.DropTable(
                name: "Heights");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.AddColumn<string>(
                name: "Aliases",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aliases",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "SuperHeroes");

            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiographySuperHeroId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliases_SuperHeroes_BiographySuperHeroId",
                        column: x => x.BiographySuperHeroId,
                        principalTable: "SuperHeroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppearanceSuperHeroId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heights_SuperHeroes_AppearanceSuperHeroId",
                        column: x => x.AppearanceSuperHeroId,
                        principalTable: "SuperHeroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppearanceSuperHeroId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weights_SuperHeroes_AppearanceSuperHeroId",
                        column: x => x.AppearanceSuperHeroId,
                        principalTable: "SuperHeroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aliases_BiographySuperHeroId",
                table: "Aliases",
                column: "BiographySuperHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Heights_AppearanceSuperHeroId",
                table: "Heights",
                column: "AppearanceSuperHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Weights_AppearanceSuperHeroId",
                table: "Weights",
                column: "AppearanceSuperHeroId");
        }
    }
}

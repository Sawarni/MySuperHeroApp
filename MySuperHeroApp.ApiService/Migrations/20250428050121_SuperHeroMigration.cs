using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySuperHeroApp.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class SuperHeroMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Intelligence = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Speed = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Durability = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Power = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Combat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlterEgos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstAppearance = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseOfOperation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GroupAffiliation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Relatives = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BiographySuperHeroId = table.Column<string>(type: "nvarchar(50)", nullable: false)
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
                    Height = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AppearanceSuperHeroId = table.Column<string>(type: "nvarchar(50)", nullable: false)
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
                    Weight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AppearanceSuperHeroId = table.Column<string>(type: "nvarchar(50)", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");

            migrationBuilder.DropTable(
                name: "Heights");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "SuperHeroes");
        }
    }
}

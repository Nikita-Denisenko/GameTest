using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWavesAndCatalogEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Waves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "int", nullable: false),
                    StartSecond = table.Column<int>(type: "int", nullable: false),
                    EndSecond = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waves", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WaveEnemy",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    WaveId = table.Column<int>(type: "int", nullable: false),
                    QuantityMin = table.Column<int>(type: "int", nullable: false),
                    QuantityMax = table.Column<int>(type: "int", nullable: false),
                    SpawnInterval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaveEnemy", x => new { x.WaveId, x.EnemyId });
                    table.ForeignKey(
                        name: "FK_WaveEnemy_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaveEnemy_Waves_WaveId",
                        column: x => x.WaveId,
                        principalTable: "Waves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WaveEnemy_EnemyId",
                table: "WaveEnemy",
                column: "EnemyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaveEnemy");

            migrationBuilder.DropTable(
                name: "Waves");
        }
    }
}

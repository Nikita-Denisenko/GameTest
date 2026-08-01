using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnemyLootConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceMax",
                table: "Enemies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceMin",
                table: "Enemies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldMax",
                table: "Enemies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldMin",
                table: "Enemies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovementType",
                table: "Enemies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemDrop",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnemyLootId = table.Column<int>(type: "int", nullable: false),
                    Chance = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDrop", x => new { x.EnemyLootId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemDrop_Enemies_EnemyLootId",
                        column: x => x.EnemyLootId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDrop");

            migrationBuilder.DropColumn(
                name: "ExperienceMax",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "ExperienceMin",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "GoldMax",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "GoldMin",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "MovementType",
                table: "Enemies");
        }
    }
}

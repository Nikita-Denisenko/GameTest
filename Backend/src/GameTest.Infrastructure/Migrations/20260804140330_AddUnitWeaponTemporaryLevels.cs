using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitWeaponTemporaryLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items_TemporaryLevels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "WeaponProperties_TemporaryLevels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "UnitProperties_TemporaryLevels");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "WeaponProperties_TemporaryLevels",
                newName: "Bonus");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "UnitProperties_TemporaryLevels",
                newName: "Bonus");

            migrationBuilder.CreateTable(
                name: "ItemTemporaryLevel",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<float>(type: "float", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTemporaryLevel", x => new { x.ItemId, x.Level });
                    table.ForeignKey(
                        name: "FK_ItemTemporaryLevel_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Units_TemporaryUpgradeLevels",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units_TemporaryUpgradeLevels", x => new { x.UnitId, x.Level });
                    table.ForeignKey(
                        name: "FK_Units_TemporaryUpgradeLevels_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Weapons_TemporaryUpgradeLevels",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons_TemporaryUpgradeLevels", x => new { x.WeaponId, x.Level });
                    table.ForeignKey(
                        name: "FK_Weapons_TemporaryUpgradeLevels_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTemporaryLevel");

            migrationBuilder.DropTable(
                name: "Units_TemporaryUpgradeLevels");

            migrationBuilder.DropTable(
                name: "Weapons_TemporaryUpgradeLevels");

            migrationBuilder.RenameColumn(
                name: "Bonus",
                table: "WeaponProperties_TemporaryLevels",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Bonus",
                table: "UnitProperties_TemporaryLevels",
                newName: "Value");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "WeaponProperties_TemporaryLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "UnitProperties_TemporaryLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Items_TemporaryLevels",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_TemporaryLevels", x => new { x.ItemId, x.Level });
                    table.ForeignKey(
                        name: "FK_Items_TemporaryLevels_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

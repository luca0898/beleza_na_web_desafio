using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BelezanaWeb.Db.SQL.Migrations.Migrations
{
    public partial class ProductInventoryWherehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                schema: "BelezanaWebDb",
                table: "Schedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 17, 18, 13, 33, 951, DateTimeKind.Local).AddTicks(7672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 11, 20, 1, 21, 24, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "BelezanaWebDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMarketable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "BelezanaWebDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Id",
                        column: x => x.Id,
                        principalSchema: "BelezanaWebDb",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "BelezanaWebDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Inventory_Id",
                        column: x => x.Id,
                        principalSchema: "BelezanaWebDb",
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "BelezanaWebDb");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "BelezanaWebDb");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "BelezanaWebDb");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                schema: "BelezanaWebDb",
                table: "Schedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 11, 20, 1, 21, 24, DateTimeKind.Local).AddTicks(753),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 17, 18, 13, 33, 951, DateTimeKind.Local).AddTicks(7672));
        }
    }
}

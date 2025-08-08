using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryMgmtSystem.Migrations
{
    /// <inheritdoc />
    public partial class alterStockmovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VatPer",
                table: "StockMovements",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VatPer",
                table: "StockMovements");
        }
    }
}

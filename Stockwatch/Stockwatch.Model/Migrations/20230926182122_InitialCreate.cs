using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockwatch.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockSymbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SymbolName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSymbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockAlertRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SymbolId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpperLimit = table.Column<decimal>(type: "TEXT", nullable: false),
                    LowerLimit = table.Column<decimal>(type: "TEXT", nullable: false),
                    StockSymbolId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAlertRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAlertRanges_StockSymbols_StockSymbolId",
                        column: x => x.StockSymbolId,
                        principalTable: "StockSymbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockAlertRanges_StockSymbolId",
                table: "StockAlertRanges",
                column: "StockSymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAlertRanges_SymbolId",
                table: "StockAlertRanges",
                column: "SymbolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockSymbols_SymbolName",
                table: "StockSymbols",
                column: "SymbolName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockAlertRanges");

            migrationBuilder.DropTable(
                name: "StockSymbols");
        }
    }
}

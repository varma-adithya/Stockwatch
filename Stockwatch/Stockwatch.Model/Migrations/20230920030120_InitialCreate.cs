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
                    table.PrimaryKey("PK_Stocksymbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SymbolId = table.Column<int>(type: "INTEGER", nullable: false),
                    Upperlimit = table.Column<decimal>(type: "TEXT", nullable: false),
                    Lowerlimit = table.Column<decimal>(type: "TEXT", nullable: false),
                    StocksymbolId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockDatas_Stocksymbols_StocksymbolId",
                        column: x => x.StocksymbolId,
                        principalTable: "StockSymbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockDatas_StocksymbolId",
                table: "StockDatas",
                column: "StocksymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDatas_SymbolId",
                table: "StockDatas",
                column: "SymbolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocksymbols_SymbolName",
                table: "StockSymbols",
                column: "SymbolName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockDatas");

            migrationBuilder.DropTable(
                name: "StockSymbols");
        }
    }
}

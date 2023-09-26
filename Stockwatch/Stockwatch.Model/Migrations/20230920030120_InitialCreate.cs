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
                name: "Stocksymbols",
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
                name: "Stockdatas",
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
                    table.PrimaryKey("PK_Stockdatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stockdatas_Stocksymbols_StocksymbolId",
                        column: x => x.StocksymbolId,
                        principalTable: "Stocksymbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stockdatas_StocksymbolId",
                table: "Stockdatas",
                column: "StocksymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Stockdatas_SymbolId",
                table: "Stockdatas",
                column: "SymbolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocksymbols_SymbolName",
                table: "Stocksymbols",
                column: "SymbolName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stockdatas");

            migrationBuilder.DropTable(
                name: "Stocksymbols");
        }
    }
}

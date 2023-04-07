using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockExchanges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Currency = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ExchangeSymbol = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    StockSymbol = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    CompanyName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    BusinessSector = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebhookSubscriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Url = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Secret = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    WebhookType = table.Column<int>(type: "int", nullable: false),
                    WebhookPublisher = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockExchangeRelationship",
                columns: table => new
                {
                    StockExchangeId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    StockId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchangeRelationship", x => new { x.StockExchangeId, x.StockId });
                    table.ForeignKey(
                        name: "FK_StockExchangeRelationship_StockExchanges_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "StockExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockExchangeRelationship_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockExchangeRelationship_StockId",
                table: "StockExchangeRelationship",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockExchangeRelationship");

            migrationBuilder.DropTable(
                name: "WebhookSubscriptions");

            migrationBuilder.DropTable(
                name: "StockExchanges");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}

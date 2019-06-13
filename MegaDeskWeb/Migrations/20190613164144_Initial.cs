using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RushShipping",
                columns: table => new
                {
                    RushShippingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RushShippingName = table.Column<string>(nullable: true),
                    RushShippingPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RushShipping", x => x.RushShippingID);
                });

            migrationBuilder.CreateTable(
                name: "SurfaceMaterial",
                columns: table => new
                {
                    SurfaceMaterialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurfaceMaterialName = table.Column<string>(nullable: true),
                    SurfaceMaterialInt = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfaceMaterial", x => x.SurfaceMaterialID);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    DeskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Width = table.Column<decimal>(nullable: false),
                    Depth = table.Column<decimal>(nullable: false),
                    NumDrawers = table.Column<int>(nullable: false),
                    SurfaceMaterialID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.DeskID);
                    table.ForeignKey(
                        name: "FK_Desk_SurfaceMaterial_SurfaceMaterialID",
                        column: x => x.SurfaceMaterialID,
                        principalTable: "SurfaceMaterial",
                        principalColumn: "SurfaceMaterialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeskID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    QuoteDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    RushShippingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteID);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_DeskID",
                        column: x => x.DeskID,
                        principalTable: "Desk",
                        principalColumn: "DeskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeskQuote_RushShipping_RushShippingID",
                        column: x => x.RushShippingID,
                        principalTable: "RushShipping",
                        principalColumn: "RushShippingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_SurfaceMaterialID",
                table: "Desk",
                column: "SurfaceMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskID",
                table: "DeskQuote",
                column: "DeskID");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_RushShippingID",
                table: "DeskQuote",
                column: "RushShippingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "RushShipping");

            migrationBuilder.DropTable(
                name: "SurfaceMaterial");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class SeedRushShipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert RushShipping VALUES (1, \"1 day shipping Large\", 80.00)");

            migrationBuilder.Sql("Insert RushShipping VALUES (2, \"1 day shipping Medium\", 70.00)");

            migrationBuilder.Sql("Insert RushShipping VALUES (3, \"1 day shipping Small\", 60.00)");

            migrationBuilder.Sql("Insert RushShipping VALUES (4, \"3 day shipping Large\", 60.00)");

            migrationBuilder.Sql("Insert RushShipping VALUES (5, \"3 day shipping Medium\", 50.00)");

            migrationBuilder.Sql("Insert RushShipping VALUES (6, \"3 day shipping Small\", 40.00)");
            migrationBuilder.Sql("Insert RushShipping VALUES (7, \"5 day shipping Large\", 40.00)");

            migrationBuilder.Sql("Insert RushShipping VALUES (8, \"5 day shipping Medium\", 35.00)");

            migrationBuilder.Sql("Insert RushShipping VALUES (9, \"5 day shipping Small\", 30.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

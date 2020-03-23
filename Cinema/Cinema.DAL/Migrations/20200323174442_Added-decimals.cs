using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.DAL.Migrations
{
    public partial class Addeddecimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(32,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "FoodProducts",
                type: "decimal(32,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidPrice",
                table: "FoodcourtChecks",
                type: "decimal(32,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidPrice",
                table: "Checks",
                type: "decimal(32,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(32,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "FoodProducts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(32,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidPrice",
                table: "FoodcourtChecks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(32,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidPrice",
                table: "Checks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(32,2)");
        }
    }
}

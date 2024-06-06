using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class AddedTotalCostToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "total_cost",
                table: "orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_cost",
                table: "orders");
        }
    }
}

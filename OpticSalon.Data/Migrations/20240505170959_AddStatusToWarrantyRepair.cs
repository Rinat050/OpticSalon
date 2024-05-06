using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class AddStatusToWarrantyRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "warranty_repairs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "warranty_repairs");
        }
    }
}

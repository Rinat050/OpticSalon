using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class AddIsActiveToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "employees");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class DeletedArticleFromFrame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "article",
                table: "frames");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "article",
                table: "frames",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

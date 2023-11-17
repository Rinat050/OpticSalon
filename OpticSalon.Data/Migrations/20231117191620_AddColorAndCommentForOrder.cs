using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class AddColorAndCommentForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "frame_color_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_orders_frame_color_id",
                table: "orders",
                column: "frame_color_id");

            migrationBuilder.AddForeignKey(
                name: "fk_orders_colors_frame_color_id",
                table: "orders",
                column: "frame_color_id",
                principalTable: "colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orders_colors_frame_color_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "ix_orders_frame_color_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "comment",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "frame_color_id",
                table: "orders");
        }
    }
}

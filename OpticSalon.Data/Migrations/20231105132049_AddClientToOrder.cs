using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class AddClientToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_client_client_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_color_db_frame_color_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_frame_material_db_frame_material_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_frame_sizes_db_frame_sizes_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_frame_type_db_frame_type_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_brand_brand_id",
                table: "frame");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_frame_material_db_material_id",
                table: "frame");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_frame_sizes_db_sizes_id",
                table: "frame");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_frame_type_db_type_id",
                table: "frame");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_gender_db_gender_id",
                table: "frame");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_color_color_color_id",
                table: "frame_color");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_color_frame_db_frame_id",
                table: "frame_color");

            migrationBuilder.DropForeignKey(
                name: "fk_order_frame_frame_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_order_lens_package_lens_package_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_order_recipe_db_recipe_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_recipe_eye_data_left_eye_id",
                table: "recipe");

            migrationBuilder.DropForeignKey(
                name: "fk_recipe_eye_data_right_eye_id",
                table: "recipe");

            migrationBuilder.DropForeignKey(
                name: "fk_recipe_purpose_purpose_id",
                table: "recipe");

            migrationBuilder.DropPrimaryKey(
                name: "pk_recipe",
                table: "recipe");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purpose",
                table: "purpose");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "pk_lens_package",
                table: "lens_package");

            migrationBuilder.DropPrimaryKey(
                name: "pk_gender",
                table: "gender");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frame_type",
                table: "frame_type");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frame_material",
                table: "frame_material");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frame_color",
                table: "frame_color");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frame",
                table: "frame");

            migrationBuilder.DropPrimaryKey(
                name: "pk_color",
                table: "color");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client",
                table: "client");

            migrationBuilder.DropPrimaryKey(
                name: "pk_brand",
                table: "brand");

            migrationBuilder.RenameTable(
                name: "recipe",
                newName: "recipes");

            migrationBuilder.RenameTable(
                name: "purpose",
                newName: "purposes");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "lens_package",
                newName: "lens_packages");

            migrationBuilder.RenameTable(
                name: "gender",
                newName: "genders");

            migrationBuilder.RenameTable(
                name: "frame_type",
                newName: "frame_types");

            migrationBuilder.RenameTable(
                name: "frame_material",
                newName: "frame_materials");

            migrationBuilder.RenameTable(
                name: "frame_color",
                newName: "frame_colors");

            migrationBuilder.RenameTable(
                name: "frame",
                newName: "frames");

            migrationBuilder.RenameTable(
                name: "color",
                newName: "colors");

            migrationBuilder.RenameTable(
                name: "client",
                newName: "clients");

            migrationBuilder.RenameTable(
                name: "brand",
                newName: "brands");

            migrationBuilder.RenameIndex(
                name: "ix_recipe_right_eye_id",
                table: "recipes",
                newName: "ix_recipes_right_eye_id");

            migrationBuilder.RenameIndex(
                name: "ix_recipe_purpose_id",
                table: "recipes",
                newName: "ix_recipes_purpose_id");

            migrationBuilder.RenameIndex(
                name: "ix_recipe_left_eye_id",
                table: "recipes",
                newName: "ix_recipes_left_eye_id");

            migrationBuilder.RenameIndex(
                name: "ix_order_recipe_id",
                table: "orders",
                newName: "ix_orders_recipe_id");

            migrationBuilder.RenameIndex(
                name: "ix_order_lens_package_id",
                table: "orders",
                newName: "ix_orders_lens_package_id");

            migrationBuilder.RenameIndex(
                name: "ix_order_frame_id",
                table: "orders",
                newName: "ix_orders_frame_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_color_frame_id",
                table: "frame_colors",
                newName: "ix_frame_colors_frame_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_color_color_id",
                table: "frame_colors",
                newName: "ix_frame_colors_color_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_type_id",
                table: "frames",
                newName: "ix_frames_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_sizes_id",
                table: "frames",
                newName: "ix_frames_sizes_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_material_id",
                table: "frames",
                newName: "ix_frames_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_gender_id",
                table: "frames",
                newName: "ix_frames_gender_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_brand_id",
                table: "frames",
                newName: "ix_frames_brand_id");

            migrationBuilder.AddColumn<int>(
                name: "client_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_recipes",
                table: "recipes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purposes",
                table: "purposes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_lens_packages",
                table: "lens_packages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_genders",
                table: "genders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frame_types",
                table: "frame_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frame_materials",
                table: "frame_materials",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frame_colors",
                table: "frame_colors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frames",
                table: "frames",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_colors",
                table: "colors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_clients",
                table: "clients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_brands",
                table: "brands",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_client_id",
                table: "orders",
                column: "client_id");

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_clients_client_id",
                table: "client_preferences",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_colors_frame_color_id",
                table: "client_preferences",
                column: "frame_color_id",
                principalTable: "colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_frame_materials_frame_material_id",
                table: "client_preferences",
                column: "frame_material_id",
                principalTable: "frame_materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_frame_sizes_frame_sizes_id",
                table: "client_preferences",
                column: "frame_sizes_id",
                principalTable: "frame_sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_frame_types_frame_type_id",
                table: "client_preferences",
                column: "frame_type_id",
                principalTable: "frame_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_colors_colors_color_id",
                table: "frame_colors",
                column: "color_id",
                principalTable: "colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_colors_frames_frame_id",
                table: "frame_colors",
                column: "frame_id",
                principalTable: "frames",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frames_brands_brand_id",
                table: "frames",
                column: "brand_id",
                principalTable: "brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frames_frame_materials_material_id",
                table: "frames",
                column: "material_id",
                principalTable: "frame_materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frames_frame_sizes_sizes_id",
                table: "frames",
                column: "sizes_id",
                principalTable: "frame_sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frames_frame_types_type_id",
                table: "frames",
                column: "type_id",
                principalTable: "frame_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frames_genders_gender_id",
                table: "frames",
                column: "gender_id",
                principalTable: "genders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_clients_client_id",
                table: "orders",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_frames_frame_id",
                table: "orders",
                column: "frame_id",
                principalTable: "frames",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_lens_packages_lens_package_id",
                table: "orders",
                column: "lens_package_id",
                principalTable: "lens_packages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_recipes_recipe_id",
                table: "orders",
                column: "recipe_id",
                principalTable: "recipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recipes_eye_data_left_eye_id",
                table: "recipes",
                column: "left_eye_id",
                principalTable: "eye_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recipes_eye_data_right_eye_id",
                table: "recipes",
                column: "right_eye_id",
                principalTable: "eye_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recipes_purposes_purpose_id",
                table: "recipes",
                column: "purpose_id",
                principalTable: "purposes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_clients_client_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_colors_frame_color_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_frame_materials_frame_material_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_frame_sizes_frame_sizes_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_client_preferences_frame_types_frame_type_id",
                table: "client_preferences");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_colors_colors_color_id",
                table: "frame_colors");

            migrationBuilder.DropForeignKey(
                name: "fk_frame_colors_frames_frame_id",
                table: "frame_colors");

            migrationBuilder.DropForeignKey(
                name: "fk_frames_brands_brand_id",
                table: "frames");

            migrationBuilder.DropForeignKey(
                name: "fk_frames_frame_materials_material_id",
                table: "frames");

            migrationBuilder.DropForeignKey(
                name: "fk_frames_frame_sizes_sizes_id",
                table: "frames");

            migrationBuilder.DropForeignKey(
                name: "fk_frames_frame_types_type_id",
                table: "frames");

            migrationBuilder.DropForeignKey(
                name: "fk_frames_genders_gender_id",
                table: "frames");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_clients_client_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_frames_frame_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_lens_packages_lens_package_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_recipes_recipe_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "fk_recipes_eye_data_left_eye_id",
                table: "recipes");

            migrationBuilder.DropForeignKey(
                name: "fk_recipes_eye_data_right_eye_id",
                table: "recipes");

            migrationBuilder.DropForeignKey(
                name: "fk_recipes_purposes_purpose_id",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_recipes",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purposes",
                table: "purposes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orders",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "ix_orders_client_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_lens_packages",
                table: "lens_packages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_genders",
                table: "genders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frames",
                table: "frames");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frame_types",
                table: "frame_types");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frame_materials",
                table: "frame_materials");

            migrationBuilder.DropPrimaryKey(
                name: "pk_frame_colors",
                table: "frame_colors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_colors",
                table: "colors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "pk_brands",
                table: "brands");

            migrationBuilder.DropColumn(
                name: "client_id",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "recipes",
                newName: "recipe");

            migrationBuilder.RenameTable(
                name: "purposes",
                newName: "purpose");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "lens_packages",
                newName: "lens_package");

            migrationBuilder.RenameTable(
                name: "genders",
                newName: "gender");

            migrationBuilder.RenameTable(
                name: "frames",
                newName: "frame");

            migrationBuilder.RenameTable(
                name: "frame_types",
                newName: "frame_type");

            migrationBuilder.RenameTable(
                name: "frame_materials",
                newName: "frame_material");

            migrationBuilder.RenameTable(
                name: "frame_colors",
                newName: "frame_color");

            migrationBuilder.RenameTable(
                name: "colors",
                newName: "color");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "client");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "brand");

            migrationBuilder.RenameIndex(
                name: "ix_recipes_right_eye_id",
                table: "recipe",
                newName: "ix_recipe_right_eye_id");

            migrationBuilder.RenameIndex(
                name: "ix_recipes_purpose_id",
                table: "recipe",
                newName: "ix_recipe_purpose_id");

            migrationBuilder.RenameIndex(
                name: "ix_recipes_left_eye_id",
                table: "recipe",
                newName: "ix_recipe_left_eye_id");

            migrationBuilder.RenameIndex(
                name: "ix_orders_recipe_id",
                table: "order",
                newName: "ix_order_recipe_id");

            migrationBuilder.RenameIndex(
                name: "ix_orders_lens_package_id",
                table: "order",
                newName: "ix_order_lens_package_id");

            migrationBuilder.RenameIndex(
                name: "ix_orders_frame_id",
                table: "order",
                newName: "ix_order_frame_id");

            migrationBuilder.RenameIndex(
                name: "ix_frames_type_id",
                table: "frame",
                newName: "ix_frame_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_frames_sizes_id",
                table: "frame",
                newName: "ix_frame_sizes_id");

            migrationBuilder.RenameIndex(
                name: "ix_frames_material_id",
                table: "frame",
                newName: "ix_frame_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_frames_gender_id",
                table: "frame",
                newName: "ix_frame_gender_id");

            migrationBuilder.RenameIndex(
                name: "ix_frames_brand_id",
                table: "frame",
                newName: "ix_frame_brand_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_colors_frame_id",
                table: "frame_color",
                newName: "ix_frame_color_frame_id");

            migrationBuilder.RenameIndex(
                name: "ix_frame_colors_color_id",
                table: "frame_color",
                newName: "ix_frame_color_color_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_recipe",
                table: "recipe",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purpose",
                table: "purpose",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order",
                table: "order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_lens_package",
                table: "lens_package",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_gender",
                table: "gender",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frame",
                table: "frame",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frame_type",
                table: "frame_type",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frame_material",
                table: "frame_material",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_frame_color",
                table: "frame_color",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_color",
                table: "color",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_client",
                table: "client",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_brand",
                table: "brand",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_client_client_id",
                table: "client_preferences",
                column: "client_id",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_color_db_frame_color_id",
                table: "client_preferences",
                column: "frame_color_id",
                principalTable: "color",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_frame_material_db_frame_material_id",
                table: "client_preferences",
                column: "frame_material_id",
                principalTable: "frame_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_frame_sizes_db_frame_sizes_id",
                table: "client_preferences",
                column: "frame_sizes_id",
                principalTable: "frame_sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_client_preferences_frame_type_db_frame_type_id",
                table: "client_preferences",
                column: "frame_type_id",
                principalTable: "frame_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_brand_brand_id",
                table: "frame",
                column: "brand_id",
                principalTable: "brand",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_frame_material_db_material_id",
                table: "frame",
                column: "material_id",
                principalTable: "frame_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_frame_sizes_db_sizes_id",
                table: "frame",
                column: "sizes_id",
                principalTable: "frame_sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_frame_type_db_type_id",
                table: "frame",
                column: "type_id",
                principalTable: "frame_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_gender_db_gender_id",
                table: "frame",
                column: "gender_id",
                principalTable: "gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_color_color_color_id",
                table: "frame_color",
                column: "color_id",
                principalTable: "color",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_frame_color_frame_db_frame_id",
                table: "frame_color",
                column: "frame_id",
                principalTable: "frame",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_frame_frame_id",
                table: "order",
                column: "frame_id",
                principalTable: "frame",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_lens_package_lens_package_id",
                table: "order",
                column: "lens_package_id",
                principalTable: "lens_package",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_recipe_db_recipe_id",
                table: "order",
                column: "recipe_id",
                principalTable: "recipe",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recipe_eye_data_left_eye_id",
                table: "recipe",
                column: "left_eye_id",
                principalTable: "eye_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recipe_eye_data_right_eye_id",
                table: "recipe",
                column: "right_eye_id",
                principalTable: "eye_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recipe_purpose_purpose_id",
                table: "recipe",
                column: "purpose_id",
                principalTable: "purpose",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

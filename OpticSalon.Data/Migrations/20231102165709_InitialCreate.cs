using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "eye_data",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sph = table.Column<double>(type: "double precision", nullable: false),
                    cyl = table.Column<double>(type: "double precision", nullable: false),
                    axis = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eye_data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "frame_material",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_frame_material", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "frame_sizes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lens_width = table.Column<int>(type: "integer", nullable: false),
                    distance_between_lens = table.Column<int>(type: "integer", nullable: false),
                    temple_lenght = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_frame_sizes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "frame_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_frame_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lens_package",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lens_package", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "purpose",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purpose", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_preferences",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    frame_type_id = table.Column<int>(type: "integer", nullable: false),
                    frame_material_id = table.Column<int>(type: "integer", nullable: false),
                    frame_color_id = table.Column<int>(type: "integer", nullable: false),
                    frame_sizes_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_preferences", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_preferences_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_client_preferences_color_db_frame_color_id",
                        column: x => x.frame_color_id,
                        principalTable: "color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_client_preferences_frame_material_db_frame_material_id",
                        column: x => x.frame_material_id,
                        principalTable: "frame_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_client_preferences_frame_sizes_db_frame_sizes_id",
                        column: x => x.frame_sizes_id,
                        principalTable: "frame_sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_client_preferences_frame_type_db_frame_type_id",
                        column: x => x.frame_type_id,
                        principalTable: "frame_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "frame",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model = table.Column<string>(type: "text", nullable: false),
                    article = table.Column<string>(type: "text", nullable: false),
                    cost = table.Column<decimal>(type: "numeric", nullable: false),
                    brand_id = table.Column<int>(type: "integer", nullable: false),
                    sizes_id = table.Column<int>(type: "integer", nullable: false),
                    material_id = table.Column<int>(type: "integer", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    gender_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_frame", x => x.id);
                    table.ForeignKey(
                        name: "fk_frame_brand_brand_id",
                        column: x => x.brand_id,
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_frame_frame_material_db_material_id",
                        column: x => x.material_id,
                        principalTable: "frame_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_frame_frame_sizes_db_sizes_id",
                        column: x => x.sizes_id,
                        principalTable: "frame_sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_frame_frame_type_db_type_id",
                        column: x => x.type_id,
                        principalTable: "frame_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_frame_gender_db_gender_id",
                        column: x => x.gender_id,
                        principalTable: "gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    left_eye_id = table.Column<int>(type: "integer", nullable: false),
                    right_eye_id = table.Column<int>(type: "integer", nullable: false),
                    dp = table.Column<int>(type: "integer", nullable: false),
                    purpose_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe", x => x.id);
                    table.ForeignKey(
                        name: "fk_recipe_eye_data_left_eye_id",
                        column: x => x.left_eye_id,
                        principalTable: "eye_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_recipe_eye_data_right_eye_id",
                        column: x => x.right_eye_id,
                        principalTable: "eye_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_recipe_purpose_purpose_id",
                        column: x => x.purpose_id,
                        principalTable: "purpose",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "frame_color",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    frame_id = table.Column<int>(type: "integer", nullable: false),
                    color_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_frame_color", x => x.id);
                    table.ForeignKey(
                        name: "fk_frame_color_color_color_id",
                        column: x => x.color_id,
                        principalTable: "color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_frame_color_frame_db_frame_id",
                        column: x => x.frame_id,
                        principalTable: "frame",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    frame_id = table.Column<int>(type: "integer", nullable: false),
                    lens_package_id = table.Column<int>(type: "integer", nullable: false),
                    lens_tinting_percent = table.Column<int>(type: "integer", nullable: false),
                    contact_phone_number = table.Column<string>(type: "text", nullable: false),
                    delivery_address = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_frame_frame_id",
                        column: x => x.frame_id,
                        principalTable: "frame",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_lens_package_lens_package_id",
                        column: x => x.lens_package_id,
                        principalTable: "lens_package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_recipe_db_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_client_preferences_client_id",
                table: "client_preferences",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_preferences_frame_color_id",
                table: "client_preferences",
                column: "frame_color_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_preferences_frame_material_id",
                table: "client_preferences",
                column: "frame_material_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_preferences_frame_sizes_id",
                table: "client_preferences",
                column: "frame_sizes_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_preferences_frame_type_id",
                table: "client_preferences",
                column: "frame_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_frame_brand_id",
                table: "frame",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_frame_gender_id",
                table: "frame",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "ix_frame_material_id",
                table: "frame",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_frame_sizes_id",
                table: "frame",
                column: "sizes_id");

            migrationBuilder.CreateIndex(
                name: "ix_frame_type_id",
                table: "frame",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_frame_color_color_id",
                table: "frame_color",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "ix_frame_color_frame_id",
                table: "frame_color",
                column: "frame_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_frame_id",
                table: "order",
                column: "frame_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_lens_package_id",
                table: "order",
                column: "lens_package_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_recipe_id",
                table: "order",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_left_eye_id",
                table: "recipe",
                column: "left_eye_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_purpose_id",
                table: "recipe",
                column: "purpose_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_right_eye_id",
                table: "recipe",
                column: "right_eye_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_preferences");

            migrationBuilder.DropTable(
                name: "frame_color");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "frame");

            migrationBuilder.DropTable(
                name: "lens_package");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "frame_material");

            migrationBuilder.DropTable(
                name: "frame_sizes");

            migrationBuilder.DropTable(
                name: "frame_type");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "eye_data");

            migrationBuilder.DropTable(
                name: "purpose");
        }
    }
}

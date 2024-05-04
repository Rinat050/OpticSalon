using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    public partial class AddWarrantyRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "defects",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_defects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "repair_works",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repair_works", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "warranty_repairs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    defect_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    issue_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    master_id = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_warranty_repairs", x => x.id);
                    table.ForeignKey(
                        name: "fk_warranty_repairs_defects_defect_id",
                        column: x => x.defect_id,
                        principalTable: "defects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_warranty_repairs_employees_master_id",
                        column: x => x.master_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_warranty_repairs_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "warranty_repair_works",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    warranty_repair_id = table.Column<int>(type: "integer", nullable: false),
                    repair_work_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_warranty_repair_works", x => x.id);
                    table.ForeignKey(
                        name: "fk_warranty_repair_works_repair_works_repair_work_id",
                        column: x => x.repair_work_id,
                        principalTable: "repair_works",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_warranty_repair_works_warranty_repairs_warranty_repair_id",
                        column: x => x.warranty_repair_id,
                        principalTable: "warranty_repairs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_warranty_repair_works_repair_work_id",
                table: "warranty_repair_works",
                column: "repair_work_id");

            migrationBuilder.CreateIndex(
                name: "ix_warranty_repair_works_warranty_repair_id",
                table: "warranty_repair_works",
                column: "warranty_repair_id");

            migrationBuilder.CreateIndex(
                name: "ix_warranty_repairs_defect_id",
                table: "warranty_repairs",
                column: "defect_id");

            migrationBuilder.CreateIndex(
                name: "ix_warranty_repairs_master_id",
                table: "warranty_repairs",
                column: "master_id");

            migrationBuilder.CreateIndex(
                name: "ix_warranty_repairs_order_id",
                table: "warranty_repairs",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "warranty_repair_works");

            migrationBuilder.DropTable(
                name: "repair_works");

            migrationBuilder.DropTable(
                name: "warranty_repairs");

            migrationBuilder.DropTable(
                name: "defects");
        }
    }
}

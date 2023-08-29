using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebShop.Core.Migrations
{
    public partial class Maindatabasemodelimplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_id = table.Column<string>(type: "text", nullable: false, comment: "Customer Id, User Identity Id"),
                    order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Date of order"),
                    is_open = table.Column<bool>(type: "boolean", nullable: false, comment: "Flag for if an order is finished"),
                    order_fulfilled_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Finished date of order")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Promotion title"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "Promotion start date"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "Promotion end date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_discounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Promotion reference"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Product reference (optional)"),
                    category_id = table.Column<int>(type: "integer", nullable: true, comment: "Category reference (optional)"),
                    brand_id = table.Column<int>(type: "integer", nullable: true, comment: "Brand reference (optional)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_discounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_promotion_discounts_promotion_promotion_id",
                        column: x => x.promotion_id,
                        principalTable: "promotion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Brand name"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Deletion flag"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brands", x => x.id);
                    table.ForeignKey(
                        name: "fk_brands_promotion_discounts_brand_id",
                        column: x => x.brand_id,
                        principalTable: "promotion_discounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Brand name"),
                    brand_img = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: true, comment: "Category img"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Deletion flag"),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_promotion_discounts_category_id",
                        column: x => x.category_id,
                        principalTable: "promotion_discounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Product Name"),
                    description = table.Column<string>(type: "character varying(700)", maxLength: 700, nullable: false, comment: "Product description"),
                    product_image = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false, comment: "Product image"),
                    price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Regular (base) price"),
                    promotional_price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Active price with applied promotions"),
                    stock_quantity = table.Column<int>(type: "integer", nullable: false, comment: "Quantity in stock"),
                    brand_id = table.Column<int>(type: "integer", nullable: false, comment: "Brand reference"),
                    category_id = table.Column<int>(type: "integer", nullable: false, comment: "Category reference"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Deletion flag"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_brands_brand_id",
                        column: x => x.brand_id,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_products_promotion_discounts_product_id",
                        column: x => x.product_id,
                        principalTable: "promotion_discounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Order reference"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Product reference"),
                    quantity = table.Column<int>(type: "integer", nullable: false, comment: "Stock quantity"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "Deletion flag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_brands_brand_id",
                table: "brands",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_category_id",
                table: "categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_order_id",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_product_id",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_brand_id",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_product_id",
                table: "products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_discounts_promotion_id",
                table: "promotion_discounts",
                column: "promotion_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "promotion_discounts");

            migrationBuilder.DropTable(
                name: "promotion");
        }
    }
}

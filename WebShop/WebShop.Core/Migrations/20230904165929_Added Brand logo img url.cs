using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Core.Migrations
{
    public partial class AddedBrandlogoimgurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "brand_logo_img",
                table: "brands",
                type: "character varying(2083)",
                maxLength: 2083,
                nullable: false,
                defaultValue: "",
                comment: "Brand logo URL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brand_logo_img",
                table: "brands");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productTypeId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_productTypeId",
                table: "Product",
                column: "productTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_productTypeId",
                table: "Product",
                column: "productTypeId",
                principalTable: "ProductType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_productTypeId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_productTypeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "productTypeId",
                table: "Product");
        }
    }
}

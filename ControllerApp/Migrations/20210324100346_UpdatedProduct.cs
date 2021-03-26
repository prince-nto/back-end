using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class UpdatedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroupDto_ProductGroupId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductGroupDto");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "ProductGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductGroupDto",
                columns: table => new
                {
                    ProductGroupDtoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroupDto", x => x.ProductGroupDtoId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroupDto_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroupDto",
                principalColumn: "ProductGroupDtoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

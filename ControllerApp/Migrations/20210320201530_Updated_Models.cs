using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class Updated_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isClosed",
                table: "Tenders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TenderId",
                table: "TenderBidSubmissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductGroupDto",
                columns: table => new
                {
                    ProductGroupDtoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroupDto", x => x.ProductGroupDtoId);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    ProductGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.ProductGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenderBidSubmissions_TenderId",
                table: "TenderBidSubmissions",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroupDto_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroupDto",
                principalColumn: "ProductGroupDtoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderBidSubmissions_Tenders_TenderId",
                table: "TenderBidSubmissions",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "TenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroupDto_ProductGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderBidSubmissions_Tenders_TenderId",
                table: "TenderBidSubmissions");

            migrationBuilder.DropTable(
                name: "ProductGroupDto");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropIndex(
                name: "IX_TenderBidSubmissions_TenderId",
                table: "TenderBidSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isClosed",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "TenderBidSubmissions");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Products");
        }
    }
}

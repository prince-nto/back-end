using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class updatedBidSubmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderBidSubmissions_Users_SumittedById",
                table: "TenderBidSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_TenderBidSubmissions_SumittedById",
                table: "TenderBidSubmissions");

            migrationBuilder.DropColumn(
                name: "SumittedById",
                table: "TenderBidSubmissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SumittedById",
                table: "TenderBidSubmissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TenderBidSubmissions_SumittedById",
                table: "TenderBidSubmissions",
                column: "SumittedById");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderBidSubmissions_Users_SumittedById",
                table: "TenderBidSubmissions",
                column: "SumittedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

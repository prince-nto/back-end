using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class UpdatedModel_Eligible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EligibleSuppliers_Companies_CompanyId",
                table: "EligibleSuppliers");

            migrationBuilder.DropIndex(
                name: "IX_EligibleSuppliers_CompanyId",
                table: "EligibleSuppliers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "EligibleSuppliers");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "EligibleSuppliers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "EligibleSuppliers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "EligibleSuppliers");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "EligibleSuppliers");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "EligibleSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EligibleSuppliers_CompanyId",
                table: "EligibleSuppliers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleSuppliers_Companies_CompanyId",
                table: "EligibleSuppliers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

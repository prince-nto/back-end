using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class AddedModelEliSupp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EligibleSuppliers",
                columns: table => new
                {
                    EligibleSupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEvaluated = table.Column<DateTime>(nullable: false),
                    Score = table.Column<string>(maxLength: 50, nullable: true),
                    InflationRate = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    TenderId = table.Column<int>(nullable: false),
                    TenderId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibleSuppliers", x => x.EligibleSupplierId);
                    table.ForeignKey(
                        name: "FK_EligibleSuppliers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EligibleSuppliers_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "TenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EligibleSuppliers_Tenders_TenderId1",
                        column: x => x.TenderId1,
                        principalTable: "Tenders",
                        principalColumn: "TenderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EligibleSuppliers_CompanyId",
                table: "EligibleSuppliers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleSuppliers_TenderId",
                table: "EligibleSuppliers",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleSuppliers_TenderId1",
                table: "EligibleSuppliers",
                column: "TenderId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EligibleSuppliers");
        }
    }
}

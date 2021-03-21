using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    VatNo = table.Column<string>(maxLength: 50, nullable: false),
                    Registration = table.Column<string>(maxLength: 50, nullable: false),
                    PhysicalAddress1 = table.Column<string>(maxLength: 50, nullable: false),
                    PhysicalAddress2 = table.Column<string>(maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(maxLength: 50, nullable: false),
                    Province = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNo = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "StateOrgans",
                columns: table => new
                {
                    StateOrganId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Region = table.Column<string>(maxLength: 50, nullable: false),
                    PhysicalAddress1 = table.Column<string>(maxLength: 50, nullable: false),
                    PhysicalAddress2 = table.Column<string>(maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(maxLength: 50, nullable: false),
                    Province = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateOrgans", x => x.StateOrganId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    TenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    CloseDate = table.Column<DateTime>(nullable: false),
                    ContactNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    StateOrganId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.TenderId);
                    table.ForeignKey(
                        name: "FK_Tenders_StateOrgans_StateOrganId",
                        column: x => x.StateOrganId,
                        principalTable: "StateOrgans",
                        principalColumn: "StateOrganId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    CellPhonenumber = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    UserTypeId = table.Column<int>(nullable: false),
                    DateUserWasAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CompanyUserId = table.Column<int>(nullable: false),
                    CompanyId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => new { x.CompanyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Companies_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderBidSubmissions",
                columns: table => new
                {
                    TenderBidSubmissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    TotalQuotation = table.Column<double>(nullable: false),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    SumittedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderBidSubmissions", x => x.TenderBidSubmissionId);
                    table.ForeignKey(
                        name: "FK_TenderBidSubmissions_Users_SumittedById",
                        column: x => x.SumittedById,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderBidSubmissionProducts",
                columns: table => new
                {
                    TenderBidSubmissionProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    RecommendedPrice = table.Column<double>(nullable: false),
                    QuotedPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TenderBidSubmissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderBidSubmissionProducts", x => x.TenderBidSubmissionProductId);
                    table.ForeignKey(
                        name: "FK_TenderBidSubmissionProducts_TenderBidSubmissions_TenderBidSubmissionId",
                        column: x => x.TenderBidSubmissionId,
                        principalTable: "TenderBidSubmissions",
                        principalColumn: "TenderBidSubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[] { 1, "User" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[] { 2, "Librarian" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[] { 3, "System" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId1",
                table: "CompanyUsers",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_UserId",
                table: "CompanyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderBidSubmissionProducts_TenderBidSubmissionId",
                table: "TenderBidSubmissionProducts",
                column: "TenderBidSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderBidSubmissions_SumittedById",
                table: "TenderBidSubmissions",
                column: "SumittedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_StateOrganId",
                table: "Tenders",
                column: "StateOrganId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TenderBidSubmissionProducts");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "TenderBidSubmissions");

            migrationBuilder.DropTable(
                name: "StateOrgans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseTracker.Api.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayeeName = table.Column<string>(type: "varchar(100)", nullable: true),
                    PurchaseAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Housing" },
                    { 2, "Transportation" },
                    { 3, "Food" },
                    { 4, "Utilities" },
                    { 5, "Medical & Healthcare" },
                    { 6, "Saving, Investing, & Debt Payments" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "CategoryId", "Memo", "PayeeName", "PurchaseAmount", "PurchaseDate" },
                values: new object[,]
                {
                    { 3, 1, "Rent.", "Property Mangement Company", 1200.00m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, "Tacos!", "Fuzzies!", 99.99m, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 4, "Less than last month. Yay!", "Electricity Company", 99.99m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, "Kid doctor appointment.", "Mercy Hostpital", 99.99m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CategoryId",
                table: "Purchases",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

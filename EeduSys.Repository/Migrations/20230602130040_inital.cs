using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSys.Repository.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 200, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatagoryId = table.Column<int>(type: "int", nullable: false),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Catagories_CatagoryId",
                        column: x => x.CatagoryId,
                        principalTable: "Catagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "CreateData", "Name", "UpdateData" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronics", null });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "CreateData", "Name", "UpdateData" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fashion", null });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "CreateData", "Name", "UpdateData" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pets", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatagoryId", "CreateData", "Name", "Price", "Stock", "UpdateData" },
                values: new object[] { 1, 1, new DateTime(2023, 6, 2, 6, 0, 40, 214, DateTimeKind.Local).AddTicks(4189), "Computer", 850m, 25m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatagoryId", "CreateData", "Name", "Price", "Stock", "UpdateData" },
                values: new object[] { 2, 2, new DateTime(2023, 6, 2, 6, 0, 40, 214, DateTimeKind.Local).AddTicks(4241), "T-Shirt", 50m, 400m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatagoryId", "CreateData", "Name", "Price", "Stock", "UpdateData" },
                values: new object[] { 3, 3, new DateTime(2023, 6, 2, 6, 0, 40, 214, DateTimeKind.Local).AddTicks(4247), "Cat food", 25m, 1000m, null });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoryId",
                table: "Products",
                column: "CatagoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Catagories");
        }
    }
}

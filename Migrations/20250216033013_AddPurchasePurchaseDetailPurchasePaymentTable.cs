using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchasePurchaseDetailPurchasePaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Deposit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasePayments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Amount", "Date", "Deposit", "Discount", "PurchaseDate", "Status", "SupplierId", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2025, 2, 16, 10, 30, 12, 289, DateTimeKind.Local).AddTicks(9880), 10m, 10m, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Local), true, 1, 2, null },
                    { 2, 300m, new DateTime(2025, 2, 16, 10, 30, 12, 289, DateTimeKind.Local).AddTicks(9890), 30m, 30m, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Local), true, 2, 3, null },
                    { 3, 200m, new DateTime(2025, 2, 16, 10, 30, 12, 289, DateTimeKind.Local).AddTicks(9890), 10m, 10m, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Local), true, 3, 1, null }
                });

            migrationBuilder.InsertData(
                table: "PurchaseDetails",
                columns: new[] { "Id", "Cost", "Discount", "ProductId", "PurchaseId", "Qty" },
                values: new object[,]
                {
                    { 1, 100m, 10m, 1, 1, 100m },
                    { 2, 300m, 30m, 2, 2, 230m },
                    { 3, 400m, 20m, 3, 3, 200m }
                });

            migrationBuilder.InsertData(
                table: "PurchasePayments",
                columns: new[] { "Id", "PayAmount", "PayDate", "PaymentMethodId", "PurchaseId", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2025, 2, 16, 10, 30, 12, 290, DateTimeKind.Local).AddTicks(380), 1, 1, 2, null },
                    { 2, 200m, new DateTime(2025, 2, 16, 10, 30, 12, 290, DateTimeKind.Local).AddTicks(380), 2, 2, 1, null },
                    { 3, 300m, new DateTime(2025, 2, 16, 10, 30, 12, 290, DateTimeKind.Local).AddTicks(390), 1, 3, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_ProductId",
                table: "PurchaseDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PaymentMethodId",
                table: "PurchasePayments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_UserId1",
                table: "PurchasePayments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId1",
                table: "Purchases",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "PurchasePayments");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}

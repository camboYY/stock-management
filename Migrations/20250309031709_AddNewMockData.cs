using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddNewMockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductUnits",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductUnits",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductId",
                value: 3);

            migrationBuilder.InsertData(
                table: "ProductUnits",
                columns: new[] { "Id", "Cost", "IsDefault", "Price", "ProductId", "UnitTypeId" },
                values: new object[,]
                {
                    { 4, 40m, false, 40m, 4, 3 },
                    { 5, 60m, false, 40m, 5, 3 },
                    { 6, 80m, false, 40m, 6, 3 }
                });

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 9, 10, 17, 7, 701, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 9, 10, 17, 7, 701, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 9, 10, 17, 7, 701, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 9, 10, 17, 7, 701, DateTimeKind.Local).AddTicks(5040), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 9, 10, 17, 7, 701, DateTimeKind.Local).AddTicks(5050), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 9, 10, 17, 7, 701, DateTimeKind.Local).AddTicks(5050), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_RateId",
                table: "Sales",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Rates_RateId",
                table: "Sales",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Rates_RateId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_RateId",
                table: "Sales");

            migrationBuilder.DeleteData(
                table: "ProductUnits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductUnits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductUnits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "ProductUnits",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductUnits",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6280), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6280), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6290), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}

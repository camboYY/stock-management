using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Warehouses_WarehouseId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_WarehouseId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Sales");

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 15, 19, 53, 19, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 15, 19, 53, 19, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 15, 19, 53, 19, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 8, 15, 19, 53, 19, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 8, 15, 19, 53, 19, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 3, 8, 15, 19, 53, 19, DateTimeKind.Local).AddTicks(6940));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 14, 19, 15, 795, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 14, 19, 15, 795, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 8, 14, 19, 15, 795, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 8, 14, 19, 15, 795, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 8, 14, 19, 15, 795, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 3, 8, 14, 19, 15, 795, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.CreateIndex(
                name: "IX_Sales_WarehouseId",
                table: "Sales",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Warehouses_WarehouseId",
                table: "Sales",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

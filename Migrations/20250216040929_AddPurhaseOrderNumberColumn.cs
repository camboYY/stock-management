using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddPurhaseOrderNumberColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseOrderNumber",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 2, 16, 11, 9, 28, 301, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 2, 16, 11, 9, 28, 301, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 2, 16, 11, 9, 28, 301, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PurchaseOrderNumber" },
                values: new object[] { new DateTime(2025, 2, 16, 11, 9, 28, 301, DateTimeKind.Local).AddTicks(4360), null });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PurchaseOrderNumber" },
                values: new object[] { new DateTime(2025, 2, 16, 11, 9, 28, 301, DateTimeKind.Local).AddTicks(4370), null });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "PurchaseOrderNumber" },
                values: new object[] { new DateTime(2025, 2, 16, 11, 9, 28, 301, DateTimeKind.Local).AddTicks(4370), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseOrderNumber",
                table: "Purchases");

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 2, 16, 10, 30, 12, 290, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 2, 16, 10, 30, 12, 290, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 2, 16, 10, 30, 12, 290, DateTimeKind.Local).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 2, 16, 10, 30, 12, 289, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 2, 16, 10, 30, 12, 289, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 2, 16, 10, 30, 12, 289, DateTimeKind.Local).AddTicks(9890));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class addCostForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cost",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "Cost",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "Cost",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "Cost",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "Cost",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "Cost",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 7, 22, 14, 41, 741, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 7, 22, 14, 41, 741, DateTimeKind.Local).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 7, 22, 14, 41, 741, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 14, 41, 741, DateTimeKind.Local).AddTicks(5541), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 14, 41, 741, DateTimeKind.Local).AddTicks(5546), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 14, 41, 741, DateTimeKind.Local).AddTicks(5550), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 6, 16, 57, 23, 994, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 6, 16, 57, 23, 994, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 6, 16, 57, 23, 994, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 6, 16, 57, 23, 994, DateTimeKind.Local).AddTicks(6520), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 6, 16, 57, 23, 994, DateTimeKind.Local).AddTicks(6530), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 6, 16, 57, 23, 994, DateTimeKind.Local).AddTicks(6530), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}

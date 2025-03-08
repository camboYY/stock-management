using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleAndSaleDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 5, 21, 23, 6, 162, DateTimeKind.Local).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 5, 21, 23, 6, 162, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 5, 21, 23, 6, 162, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 5, 21, 23, 6, 162, DateTimeKind.Local).AddTicks(6110), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 5, 21, 23, 6, 162, DateTimeKind.Local).AddTicks(6120), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 5, 21, 23, 6, 162, DateTimeKind.Local).AddTicks(6130), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}

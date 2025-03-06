using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddBeginBalanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PayDate",
                value: new DateTime(2025, 3, 3, 20, 43, 9, 209, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PayDate",
                value: new DateTime(2025, 3, 3, 20, 43, 9, 209, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "PurchasePayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PayDate",
                value: new DateTime(2025, 3, 3, 20, 43, 9, 209, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 3, 20, 43, 9, 209, DateTimeKind.Local).AddTicks(2020), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 3, 20, 43, 9, 209, DateTimeKind.Local).AddTicks(2030), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 3, 3, 20, 43, 9, 209, DateTimeKind.Local).AddTicks(2030), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}

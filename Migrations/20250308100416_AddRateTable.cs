using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddRateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PreparedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceNumber",
                table: "Sales",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

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
                column: "Date",
                value: new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 3, 8, 17, 4, 15, 33, DateTimeKind.Local).AddTicks(6290));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.AlterColumn<int>(
                name: "PreparedBy",
                table: "Sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceNumber",
                table: "Sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}

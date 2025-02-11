using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddOtherExpenseTypeAndOtherIncomeTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherIncomeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncomeTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OtherExpenseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Salary expense" },
                    { 2, "Interest expense" },
                    { 3, "Fee expense" }
                });

            migrationBuilder.InsertData(
                table: "OtherIncomeTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Other incomes" },
                    { 2, "Interest income" },
                    { 3, "Fee income" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherExpenseTypes");

            migrationBuilder.DropTable(
                name: "OtherIncomeTypes");
        }
    }
}

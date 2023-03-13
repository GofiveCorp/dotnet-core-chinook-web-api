using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChinook.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceLineTodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceLine",
                columns: table => new
                {
                    InvoiceLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLine", x => x.InvoiceLineId);
                });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 15, 16, 57, 608, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 15, 16, 57, 608, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 15, 16, 57, 608, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 15, 16, 57, 608, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 15, 16, 57, 608, DateTimeKind.Local).AddTicks(4956));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLine");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1883));
        }
    }
}

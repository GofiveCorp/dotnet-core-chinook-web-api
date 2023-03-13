using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChinook.Migrations
{
    /// <inheritdoc />
    public partial class AddForignKeyToInvoiceLineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceLine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 16, 18, 8, 657, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 16, 18, 8, 657, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 16, 18, 8, 657, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 16, 18, 8, 657, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 8, 16, 18, 8, 657, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_InvoiceId",
                table: "InvoiceLine",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLine_Invoice_InvoiceId",
                table: "InvoiceLine",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLine_Invoice_InvoiceId",
                table: "InvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLine_InvoiceId",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceLine");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChinook.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToInvoiceLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackID",
                table: "InvoiceLine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 13, 9, 25, 57, 249, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 13, 9, 25, 57, 249, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 13, 9, 25, 57, 249, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 13, 9, 25, 57, 249, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 13, 9, 25, 57, 249, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_TrackID",
                table: "InvoiceLine",
                column: "TrackID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLine_Track_TrackID",
                table: "InvoiceLine",
                column: "TrackID",
                principalTable: "Track",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLine_Track_TrackID",
                table: "InvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLine_TrackID",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "TrackID",
                table: "InvoiceLine");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 41, 46, 421, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 41, 46, 421, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 41, 46, 421, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 41, 46, 421, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 41, 46, 421, DateTimeKind.Local).AddTicks(4664));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChinook.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 22, 34, 158, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 22, 34, 158, DateTimeKind.Local).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 22, 34, 158, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 22, 34, 158, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 22, 34, 158, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EmployeeId",
                table: "Customer",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Employee_EmployeeId",
                table: "Customer",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Employee_EmployeeId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_EmployeeId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Customer");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 0, 8, 959, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 0, 8, 959, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 0, 8, 959, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 0, 8, 959, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 0, 8, 959, DateTimeKind.Local).AddTicks(7871));
        }
    }
}

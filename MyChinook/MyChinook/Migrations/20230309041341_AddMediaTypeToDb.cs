using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChinook.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaTypeToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    MediaTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.MediaTypeId);
                });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 11, 13, 41, 46, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 11, 13, 41, 46, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 11, 13, 41, 46, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 11, 13, 41, 46, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 11, 13, 41, 46, DateTimeKind.Local).AddTicks(9272));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 10, 28, 24, 911, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 10, 28, 24, 911, DateTimeKind.Local).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 10, 28, 24, 911, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 10, 28, 24, 911, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 10, 28, 24, 911, DateTimeKind.Local).AddTicks(5610));
        }
    }
}

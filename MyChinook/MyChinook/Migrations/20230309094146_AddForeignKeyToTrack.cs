using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChinook.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToTrack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediaTypeId",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Track_AlbumId",
                table: "Track",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_GenreId",
                table: "Track",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_MediaTypeId",
                table: "Track",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Album_AlbumId",
                table: "Track",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Genre_GenreId",
                table: "Track",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_MediaType_MediaTypeId",
                table: "Track",
                column: "MediaTypeId",
                principalTable: "MediaType",
                principalColumn: "MediaTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Album_AlbumId",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Genre_GenreId",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_MediaType_MediaTypeId",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_AlbumId",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_GenreId",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_MediaTypeId",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "MediaTypeId",
                table: "Track");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 24, 34, 176, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 24, 34, 176, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 24, 34, 176, DateTimeKind.Local).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 24, 34, 176, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "HireDate",
                value: new DateTime(2023, 3, 9, 16, 24, 34, 176, DateTimeKind.Local).AddTicks(4792));
        }
    }
}

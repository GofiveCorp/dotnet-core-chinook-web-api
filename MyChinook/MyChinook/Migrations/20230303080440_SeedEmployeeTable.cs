using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyChinook.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Address", "BirthDate", "City", "Country", "Email", "Fax", "FirstName", "HireDate", "LastName", "Phone", "PostalCode", "ReportsTo", "State", "Title" },
                values: new object[,]
                {
                    { 1, "11120 Jasper Ave NW", null, "Edmonton", "Canada", "andrew@chinookcorp.com", "+1 (780) 428-3457", "Andrew", null, "Adams", "+1 (780) 428-9482", "T5K 2N1", null, "AB", "General Manager" },
                    { 2, "825 8 Ave SW", null, "Calgary", "Canada", "nancy@chinookcorp.com", "+1 (403) 262-3322", "Nancy", null, "Edwards", "+1 (403) 262-3443", "T2P 2T3", 1, "AB", "Sales Manager" },
                    { 3, "1111 6 Ave SW", null, "Edmonton", "Canada", "jane@chinookcorp.com", "+1 (403) 262-6712", "Jane", null, "Peacock", "+1 (403) 262-3443", "T2P 5M5", 2, "AB", "Sales Support Agent" },
                    { 4, "683 10 Street SW", null, "Edmonton", "Canada", "margaret@chinookcorp.com", "+1 (403) 263-4289", "Margaret", null, "Park", "+1 (403) 263-4423", "T2P 5G3", 2, "AB", "Sales Support Agent" },
                    { 5, "7727B 41 Ave", null, "Edmonton", "Canada", "steve@chinookcorp.com", "+1 (780) 836-9543", "Steve", null, "Johnson", "+1 (780) 836-9987", "T3B 1Y7", 2, "AB", "Sales Support Agent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5);
        }
    }
}

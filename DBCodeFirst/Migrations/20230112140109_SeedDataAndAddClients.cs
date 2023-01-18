using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAndAddClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CLientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Caracteristic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Caracteristic", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "He is A", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6708), "A", "B" },
                    { 2, "He is B", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6714), "B", "B" },
                    { 3, null, new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6718), "C", "C" },
                    { 4, "He is D", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6721), "D", "B" },
                    { 5, null, new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6724), "E", "B" }
                });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "OfficeId", "Location", "Title" },
                values: new object[] { 1, "New York", "MMM" });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "Name" },
                values: new object[] { 1, "T" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "DateOfBirth", "FirstName", "HiredDate", "LastName", "OfficeId", "TitleId" },
                values: new object[] { 1, null, "Slavick", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6654), "Crumn", 1, 1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "CLientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 100m, 1, "A", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6730) },
                    { 2, 110m, 2, "B", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6734) },
                    { 3, 110m, 3, "C", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6737) },
                    { 4, 200m, 4, "D", new DateTime(2023, 1, 12, 16, 1, 8, 994, DateTimeKind.Local).AddTicks(6740) },
                    { 5, 90m, 5, "E", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProject",
                columns: new[] { "EmployeeProjectId", "EmployeeId", "ProjectId", "Rate", "StarteDate" },
                values: new object[,]
                {
                    { 1, 1, 1, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 2, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 3, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 4, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 5, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CLientId",
                table: "Project",
                column: "CLientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_CLientId",
                table: "Project",
                column: "CLientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_CLientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_CLientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CLientId",
                table: "Project");
        }
    }
}

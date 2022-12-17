using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace team1backendcsharpquizapi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("5a346a66-eeec-48f0-a1c8-e8a863374551"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("f4ddd58f-97b9-49b2-8617-07901860dd99"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("f6609ae1-ddf3-4969-af45-aa80ebd3f30c"));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Category", "Language", "QuestionString" },
                values: new object[,]
                {
                    { new Guid("cee56094-cea4-4d51-83bf-302a4ec3d41b"), "Serier", "Swedish", "Fråga 3" },
                    { new Guid("e028a100-3497-405e-8943-a15c4b193b08"), "Film", "Swedish", "Fråga 2" },
                    { new Guid("eb11e3d2-a64f-43c3-bee8-12824d8e788c"), "Sport", "Swedish", "Fråga 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("cee56094-cea4-4d51-83bf-302a4ec3d41b"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e028a100-3497-405e-8943-a15c4b193b08"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("eb11e3d2-a64f-43c3-bee8-12824d8e788c"));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Category", "Language", "QuestionString" },
                values: new object[,]
                {
                    { new Guid("5a346a66-eeec-48f0-a1c8-e8a863374551"), "Film", "Swedish", "Fråga 2" },
                    { new Guid("f4ddd58f-97b9-49b2-8617-07901860dd99"), "Sport", "Swedish", "Fråga 1" },
                    { new Guid("f6609ae1-ddf3-4969-af45-aa80ebd3f30c"), "Serier", "Swedish", "Fråga 3" }
                });
        }
    }
}

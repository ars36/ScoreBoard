using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScoreBoard.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "UserId", "Birthday", "Gender", "ImageUrl", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "https://placehold.co/600x400", "Lê Đức Tài", 1234567890 },
                    { 2, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://placehold.co/600x400", "Trần Văn A", 1234567891 },
                    { 3, new DateTime(1999, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "https://placehold.co/600x400", "Nguyễn Thị C", 1234567892 }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "ScoreId", "Month", "UserId", "UserScore" },
                values: new object[,]
                {
                    { 1, 8, 1, 2 },
                    { 2, 9, 1, 3 },
                    { 3, 8, 2, 4 },
                    { 4, 9, 2, 5 },
                    { 5, 8, 3, 0 },
                    { 6, 9, 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}

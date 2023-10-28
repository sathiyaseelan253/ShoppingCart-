using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingCart.services.CoupenAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CoupenCode",
                table: "Coupen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Coupen",
                columns: new[] { "CoupenId", "CoupenCode", "DiscountAmount", "MinAmount" },
                values: new object[,]
                {
                    { 1, "Coupen1", 100m, 400 },
                    { 2, "Coupen3", 90m, 872 },
                    { 3, "Coupen3", 98m, 748 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupen",
                keyColumn: "CoupenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupen",
                keyColumn: "CoupenId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupen",
                keyColumn: "CoupenId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CoupenCode",
                table: "Coupen",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

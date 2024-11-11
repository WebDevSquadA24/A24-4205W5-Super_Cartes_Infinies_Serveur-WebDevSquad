using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "961c6e2c-ee72-4d74-942c-9926cb48580d", "AQAAAAIAAYagAAAAEM0KQ/RzavbkdIRnCfDXPhQ7TBUSVHhhVy7z/ttd0n/oJYcOfy+ADTWaXOUbl6BdjQ==", "71dff3a8-d0d4-4278-b0af-fe816932732f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e692f374-b1c6-4718-af9e-e3299b811849", "13814889-1f19-4807-88a9-d73604f8501f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "74e66e0f-839d-4801-99c8-1704930fa58d", "42bcae6a-d33d-44b5-83c1-8589b9fd728f" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "Rarity",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b624719-60ca-4c7c-8bbf-f4de18a9eee4", "AQAAAAIAAYagAAAAEBx9tQ4orZB9qtQFcwOyhT69ZflwTk7T+hicotfC/1Zm1W7sciYEnpYBkIMojq7X+Q==", "cfa267de-54c9-46c3-875c-2366d2343cb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cf1121c6-d0d6-412d-85bf-8d63948b5fbe", "44b21a32-ad90-40eb-9d05-1b30a963a11d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a9c7c343-28bb-42e9-9ffd-ba29efb3bec2", "f03d9aea-f20d-4783-9e37-31268c1c37e6" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "Rarity",
                value: 0);
        }
    }
}

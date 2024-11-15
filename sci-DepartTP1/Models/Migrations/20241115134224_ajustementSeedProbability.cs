using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementSeedProbability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d35b136-94ab-4c2d-9fd0-dc738576f576", "AQAAAAIAAYagAAAAEFplf3pRnm7sxuJnwfUU/6pOEmJtvyGAPxvKfE52qdjSKfkm3ffJJdH9xnpqRBcbRQ==", "27747964-787b-4f4b-9c61-088a39bdd423" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78a7b9b0-01c1-46c5-b26e-61e38f21aeb7", "5100384b-7b62-4fed-9710-1b6806dcdd82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0b2f7673-6d5f-4e32-99c1-81d2b384fae5", "f371f3e6-a5ea-464e-9f8e-54e0d46d9914" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7745de87-fbca-487d-a621-25f9b173e322", "AQAAAAIAAYagAAAAEBc4UFgxAL9UbPrWAYMbXr8KXeYFGWaKJJhLRqxOfPwWfmFe97qCYbDfezAGkdjaFw==", "f3eae262-b224-41ce-8117-22fe50dff3f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "02fad762-78c8-4dce-83eb-8ecf7e746374", "048a7040-6e52-4d2c-8a4d-ad4daf117d66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fc476a7a-ff0b-4b04-bd3d-d73820ed9086", "21606440-3aa4-4710-bbe3-e95075758da5" });
        }
    }
}

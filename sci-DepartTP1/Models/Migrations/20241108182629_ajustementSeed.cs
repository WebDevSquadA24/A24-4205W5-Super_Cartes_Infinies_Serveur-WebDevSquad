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
                values: new object[] { "6be1eec2-8178-4a51-a22c-456d1003d12e", "AQAAAAIAAYagAAAAEM4kSUxA3ekUPykNCL6dR+F50oYU/e04bhV1/jv4/xYHxXIHTbuS/kbwCs2PwnBoNg==", "c13c0211-e361-4b1e-a95d-995cc62dfefe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a63c516e-1eb3-473d-9e80-cba45f0f42b3", "c816de0c-092e-4136-bc37-f41966ef042b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8b9e3f17-944c-4a6c-982c-85cd097801f5", "e16d3801-3554-49c3-8538-6cc2786c4f82" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6495bb5d-1fb2-41db-81a8-fb7b44bd4439", "AQAAAAIAAYagAAAAEKyrui6bIcQrZJg4OnYmpXCZw182s/Vp+uDCJydjb3QkpUKgl8vjfyVSIei/JK42Uw==", "de9e67f9-f801-4760-a8f4-57532fd55269" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc4a1d8d-fdf6-42ce-b461-b85dd7c3b634", "f1bfd452-c12c-4695-9d32-e1913a2052c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d27aa68-286a-47d6-8988-ed2b7a86682e", "ac0adf9f-cd77-4fa9-83fe-2579f2099542" });
        }
    }
}

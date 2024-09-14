using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajoutSeedGameConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "345e7250-30b9-4c84-899d-2deeec053aa0", "AQAAAAIAAYagAAAAEE+ms8YXOhY34vpoeAsMZMqdujJyi6d92uJ5lCQAESX0qXmb1HvE1uezCbbrQfHIRQ==", "85a3c604-bc43-4c23-b18a-ecac66bd5b08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9728e41d-ac2b-43fd-ba14-7bfa092eac0e", "18844e09-2b3c-46f3-949e-fc3a6a954f37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6c04cb3e-e2df-4580-bb3d-6a049138d19b", "d7d373c9-fba4-41a5-90da-70236320654a" });

            migrationBuilder.InsertData(
                table: "GameConfigs",
                columns: new[] { "Id", "NbCardsToDraw", "NbManaToReceive" },
                values: new object[] { 1, 4, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "004a5a7c-4681-4102-a8e0-b70126852862", "AQAAAAIAAYagAAAAEM7T2kEmBACg47SOAIbU55JFO/Vbkn0sAgHzS0k2dooDsVHLt7SJBzQbilENOJXKsw==", "9f503233-5147-4378-a7bf-03ff120bd1c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5c8cd486-75e7-48eb-95bb-63e815310afd", "23a6ba56-605c-4fca-97f3-11b237e093be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c4677b3e-9340-4f72-9b11-620299b10ff2", "714a1267-39bb-4ad7-b88f-58e64a773da1" });
        }
    }
}

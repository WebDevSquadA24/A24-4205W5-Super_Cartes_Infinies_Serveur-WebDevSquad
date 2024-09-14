using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class creationStartedCardEtGameConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbCardsToDraw = table.Column<int>(type: "int", nullable: false),
                    NbManaToReceive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarterCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarterCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarterCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbc7122a-ae48-477b-b716-66c801b99bf6", "AQAAAAIAAYagAAAAEGhBHQwPwV5VK/4gWHu7b/Fj3s0ZuHHhc5DZCMsPvw91Ya2VK6tM9Vn1B2ZRrLWVIQ==", "df0bd143-a3e6-4519-89b3-801401dd8cbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f795f30c-3bf7-492d-9be3-ae1d279a3b85", "aa5c7578-cf9b-4131-aec0-d63924604ee3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "997647ff-f91d-426a-bba1-71ff1e9547bd", "56982eb5-9fb1-4b35-9954-9b578b67096a" });

            migrationBuilder.CreateIndex(
                name: "IX_StarterCards_CardId",
                table: "StarterCards",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameConfigs");

            migrationBuilder.DropTable(
                name: "StarterCards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a8cb505-c286-49ea-b2c1-d3970a791fcf", "AQAAAAIAAYagAAAAECi3WHFUt7MBCqKF3CnjMNyywKHZcr/TpXd32saRCqx8xcaDpoE6xjOZHY0a0CCtlw==", "00529dbf-5231-4890-a50d-21125e3ecf4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7e01982d-3940-4c37-9133-645693588575", "19060b2d-35b6-4792-9db6-3a4cb5c6955f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "06afa481-b777-40dd-bbf1-bf43a2f7ee5a", "ce1857e9-604e-4adc-93cc-02b7eb2ee061" });
        }
    }
}

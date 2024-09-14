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
                values: new object[] { "f649e25e-978a-4860-bc2d-33fe0afa585d", "AQAAAAIAAYagAAAAEFcy1xvPtR1YgUCL0sUCy8QVY6DnW2AdUlbdRkb9yFlEmnmm+TTyqWXYFiO/bc1/ng==", "06956089-b45a-44f5-8fa4-1d1abcc57125" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7988fa1f-c88e-4aea-8925-8602907cd638", "b8a0cc46-a268-4b50-b2c8-0014c64abd16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "22dc6939-d77b-44ca-aecd-70d3e006b5c2", "8d276324-8cf6-4695-8123-51dc73794513" });

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

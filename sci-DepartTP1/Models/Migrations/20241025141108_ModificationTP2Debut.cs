using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ModificationTP2Debut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbMaxCard",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbMaxDeck",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Power",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnedCardDeck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckId = table.Column<int>(type: "int", nullable: false),
                    OwnedCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedCardDeck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedCardDeck_Deck_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedCardDeck_OwnedCards_OwnedCardId",
                        column: x => x.OwnedCardId,
                        principalTable: "OwnedCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PowerId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPower_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPower_Power_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Power",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b0dfb02-0558-4a7b-8f0d-f9b277e19e09", "AQAAAAIAAYagAAAAEG6BPF7wtEgLpAcB75H8DASKuDtp/IwmDiCEasYkKzF3xN75IhrFStUaNHqDoLR0Bw==", "2fe4c6c9-a605-4465-a22e-6b0c72f66ad9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "717be183-11f3-4610-b5de-cc5c124d0401", "da7cf197-d6ae-4dc3-bd24-3ab486d8af36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8cf92d9-39ac-4fe7-8185-e51994ee5fc5", "477f7515-c7cf-403c-9230-5f331dd1d698" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NbMaxCard", "NbMaxDeck" },
                values: new object[] { 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_CardPower_CardId",
                table: "CardPower",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPower_PowerId",
                table: "CardPower",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCardDeck_DeckId",
                table: "OwnedCardDeck",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCardDeck_OwnedCardId",
                table: "OwnedCardDeck",
                column: "OwnedCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardPower");

            migrationBuilder.DropTable(
                name: "OwnedCardDeck");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropColumn(
                name: "NbMaxCard",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "NbMaxDeck",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Cards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dcfb2a2-96cb-4b8e-bf4c-c1ce76274e9d", "AQAAAAIAAYagAAAAEGtBYaNEQYtS7SYCmgVTeJm0RirmS+WretihTP1tE2ieKfHpudnOhGYvfy56BjQ5ow==", "bbc15009-c9f5-4829-8852-ba1255cca307" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f6074f06-0629-4dfa-bf47-c8f0b4ad6390", "889a7b3d-6e17-4364-b44b-9eefeb5f64fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "758c2b86-a1d4-4deb-8fe0-8543e66dbc13", "bc0df590-1f7d-410c-9d94-4916ff15ce91" });
        }
    }
}

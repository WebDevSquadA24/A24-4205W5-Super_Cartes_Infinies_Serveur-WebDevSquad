using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class RelationDeckOwnedCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedCardDeck");

            migrationBuilder.CreateTable(
                name: "DeckOwnedCard",
                columns: table => new
                {
                    DecksId = table.Column<int>(type: "int", nullable: false),
                    OwnedCardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckOwnedCard", x => new { x.DecksId, x.OwnedCardsId });
                    table.ForeignKey(
                        name: "FK_DeckOwnedCard_Deck_DecksId",
                        column: x => x.DecksId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckOwnedCard_OwnedCards_OwnedCardsId",
                        column: x => x.OwnedCardsId,
                        principalTable: "OwnedCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "530fd708-bdb9-41fa-81cd-0b5e8bbd0ca0", "AQAAAAIAAYagAAAAEHkSSeF6VRhF4CMTJ/NIkcm4cFkhxy4oYuj4O+0N/nZBWOKm++siLu9QPKYHh3mmDg==", "df69f4e4-31e7-4231-9630-b9c1bf65bbec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a5618d1f-e9ea-4a7e-b29b-3be63bceebb2", "ef218e82-1efb-46aa-a543-311642ec2065" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5e534a00-9654-447d-9c79-45f0663d3b6f", "0cb327f2-1583-41ff-b2c2-51eb61b33618" });

            migrationBuilder.CreateIndex(
                name: "IX_DeckOwnedCard_OwnedCardsId",
                table: "DeckOwnedCard",
                column: "OwnedCardsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckOwnedCard");

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

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCardDeck_DeckId",
                table: "OwnedCardDeck",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCardDeck_OwnedCardId",
                table: "OwnedCardDeck",
                column: "OwnedCardId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class addOwnedCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnedCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedCards_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a834568-564f-43d3-af90-410e45ce1644", "AQAAAAIAAYagAAAAEBC9ia4pKp+SbdwJ/KSbisViKVecfvD2P7oUuB7N+ITo3dRVqQpQb7eWx7iDJhthCg==", "7a8ab4d1-9e1d-49e6-81b5-d94770b3a71d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e104bc97-e144-4e4e-863b-b6908916237f", "f9f5bc49-6c26-4837-bf5a-82ec84c95601" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f57d5ee9-7299-4c71-8f99-82bb2a4f0843", "57a29d0f-be0b-4032-8f45-8142413a327c" });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCards_CardId",
                table: "OwnedCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCards_PlayerId",
                table: "OwnedCards",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedCards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a69b3f0d-e5d4-4d74-9395-c077ac38332c", "AQAAAAIAAYagAAAAEMzi9Y3Z9VQFtv/YcPfjW2s5giDC2+CSq1jCOjFFS7epr2d/7zFqik5tTS+ZJcTXBg==", "c48fbe70-54c2-4fee-a831-cf5a8fcc4c43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "026cdab6-b452-424f-9637-2851346305de", "f964c7f1-2b94-4450-a6e2-51a7b402aefc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "685dc6d8-412c-45bc-a4e7-aebf19792dca", "a2e6104d-dfcf-45be-a807-f50b435d3290" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedMaxDeckAndCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Deck",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b3c242c-43c9-458f-9028-7c687e45dfbc", "AQAAAAIAAYagAAAAEK8t2CenNY/ftjz+4XvWXPA+6MHB19Z1uZQ8CsqIau/l+/9xFEbEiuCNAzGzJBMipg==", "5463d306-31fe-4f02-b769-70fa341a2e7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "abf87044-3e69-4d38-a7c2-27baf3c10318", "dfcf4aeb-9725-44fe-9356-d00e8656e469" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4f3c0d9c-cd74-4399-bddb-9d262c1bfd4d", "49a264fc-bfc1-4d2e-9e0f-07f8a6bdb392" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NbMaxCard", "NbMaxDeck" },
                values: new object[] { 8, 5 });

            migrationBuilder.AddForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Deck",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c1c3237-8e1e-4a91-89a7-3f3abe4afcc0", "AQAAAAIAAYagAAAAEJ8D1JfpaIh/CMerVq6keWdhqDWNNupoZp9pjuchwUt1tPvLFuI0MM4GlqhiaS6N4w==", "585b0e86-20a4-4a4f-8de3-c8a66c0d01e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92adc32c-b259-48e2-beda-993b13d480f4", "9c6c7756-2d89-4bf1-8d9d-58fddada4ce1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4718a51c-4ef9-4712-a6a0-176e136ec66a", "9b23e65d-1205-40be-8558-793256a3f130" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NbMaxCard", "NbMaxDeck" },
                values: new object[] { 0, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}

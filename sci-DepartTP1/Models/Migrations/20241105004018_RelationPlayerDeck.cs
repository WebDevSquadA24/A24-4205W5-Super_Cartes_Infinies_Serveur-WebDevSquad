using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class RelationPlayerDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Deck",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Deck_PlayerId",
                table: "Deck",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck");

            migrationBuilder.DropIndex(
                name: "IX_Deck_PlayerId",
                table: "Deck");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Deck");

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
        }
    }
}

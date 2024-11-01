using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class add_Name_Desc_Icon_in_Power : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPower_Cards_CardId",
                table: "CardPower");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCard_Cards_CardId",
                table: "PlayableCard");

            migrationBuilder.DropForeignKey(
                name: "FK_StarterCards_Cards_CardId",
                table: "StarterCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Power",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconURL",
                table: "Power",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Power",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "744e90ab-53f4-47fb-9ffd-e917d8a5f795", "AQAAAAIAAYagAAAAEKGE9eQqZK/a2Bzpqp9A8WVR3nozatuGYJpDHaUoHJMa1BobLyPbAQOsPw7eA+AxNw==", "94407ea8-d9d9-47c4-9513-cf1e6aee2ea7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47eddf92-4b82-4826-8ef0-854587b3e35d", "dfa012f5-b845-4366-adea-559275e5cd34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb5ac7b2-a40f-49b3-9283-27e46e2a4d30", "426899c6-b131-4ffd-8e45-3dc6f7a11a7c" });

            migrationBuilder.AddForeignKey(
                name: "FK_CardPower_Card_CardId",
                table: "CardPower",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCards_Card_CardId",
                table: "OwnedCards",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCard_Card_CardId",
                table: "PlayableCard",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StarterCards_Card_CardId",
                table: "StarterCards",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPower_Card_CardId",
                table: "CardPower");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCards_Card_CardId",
                table: "OwnedCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCard_Card_CardId",
                table: "PlayableCard");

            migrationBuilder.DropForeignKey(
                name: "FK_StarterCards_Card_CardId",
                table: "StarterCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "IconURL",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Power");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CardPower_Cards_CardId",
                table: "CardPower",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCard_Cards_CardId",
                table: "PlayableCard",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StarterCards_Cards_CardId",
                table: "StarterCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class addDbSetPlayableCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCard_Cards_CardId",
                table: "PlayableCard");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId",
                table: "PlayableCard");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId1",
                table: "PlayableCard");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId2",
                table: "PlayableCard");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId3",
                table: "PlayableCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayableCard",
                table: "PlayableCard");

            migrationBuilder.RenameTable(
                name: "PlayableCard",
                newName: "PlayableCards");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCard_MatchPlayerDataId3",
                table: "PlayableCards",
                newName: "IX_PlayableCards_MatchPlayerDataId3");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCard_MatchPlayerDataId2",
                table: "PlayableCards",
                newName: "IX_PlayableCards_MatchPlayerDataId2");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCard_MatchPlayerDataId1",
                table: "PlayableCards",
                newName: "IX_PlayableCards_MatchPlayerDataId1");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCard_MatchPlayerDataId",
                table: "PlayableCards",
                newName: "IX_PlayableCards_MatchPlayerDataId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCard_CardId",
                table: "PlayableCards",
                newName: "IX_PlayableCards_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayableCards",
                table: "PlayableCards",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7ef059e-2d27-4b0f-903f-954f3bd5a3f4", "AQAAAAIAAYagAAAAEOqlS+dPJOa9KsxVDGUOQJZpy3KEozegLOQivPlBfje2r9yC9H0otwl9E9KlzME/4A==", "4b64a045-8e13-40b2-b9cb-1f511099cc50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1be25e47-4335-4e54-a358-1fd20f2049bb", "e16f8b16-d7db-4c8e-a432-4622070fbbcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "811a40bd-7de0-4c81-89a1-48b7f4b3d349", "aba2d0dc-ece6-4462-be7c-72105665a9b3" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCards_Cards_CardId",
                table: "PlayableCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId",
                table: "PlayableCards",
                column: "MatchPlayerDataId",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId1",
                table: "PlayableCards",
                column: "MatchPlayerDataId1",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId2",
                table: "PlayableCards",
                column: "MatchPlayerDataId2",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId3",
                table: "PlayableCards",
                column: "MatchPlayerDataId3",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCards_Cards_CardId",
                table: "PlayableCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId",
                table: "PlayableCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId1",
                table: "PlayableCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId2",
                table: "PlayableCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId3",
                table: "PlayableCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayableCards",
                table: "PlayableCards");

            migrationBuilder.RenameTable(
                name: "PlayableCards",
                newName: "PlayableCard");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCards_MatchPlayerDataId3",
                table: "PlayableCard",
                newName: "IX_PlayableCard_MatchPlayerDataId3");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCards_MatchPlayerDataId2",
                table: "PlayableCard",
                newName: "IX_PlayableCard_MatchPlayerDataId2");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCards_MatchPlayerDataId1",
                table: "PlayableCard",
                newName: "IX_PlayableCard_MatchPlayerDataId1");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCards_MatchPlayerDataId",
                table: "PlayableCard",
                newName: "IX_PlayableCard_MatchPlayerDataId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCards_CardId",
                table: "PlayableCard",
                newName: "IX_PlayableCard_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayableCard",
                table: "PlayableCard",
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
                name: "FK_PlayableCard_Cards_CardId",
                table: "PlayableCard",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId",
                table: "PlayableCard",
                column: "MatchPlayerDataId",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId1",
                table: "PlayableCard",
                column: "MatchPlayerDataId1",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId2",
                table: "PlayableCard",
                column: "MatchPlayerDataId2",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId3",
                table: "PlayableCard",
                column: "MatchPlayerDataId3",
                principalTable: "MatchPlayersData",
                principalColumn: "Id");
        }
    }
}

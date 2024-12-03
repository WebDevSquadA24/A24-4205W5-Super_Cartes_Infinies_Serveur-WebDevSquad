using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajoutPlayerInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerInfo1Id",
                table: "PairOfPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerInfo2Id",
                table: "PairOfPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac35d8dd-c8ef-44a5-9cd3-07dd59223570", "AQAAAAIAAYagAAAAEGzTx5eMwG8k/KOC5KTEdTk6FTYtcVTgoXkVis4yuGAZuJuYexMfIFsAaRv+XimCXA==", "e61b00e2-45c6-435f-ab91-6fe4036d3c0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fe498875-a6e4-44dd-85b8-4aa09c4b11fa", "ebcef5ab-ac25-49f1-b199-2678c5234012" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "360457c8-f333-40d3-958d-da0b492a6509", "5bcc0c0a-0ec4-415f-bbb6-dc872067dc82" });

            migrationBuilder.CreateIndex(
                name: "IX_PairOfPlayers_PlayerInfo1Id",
                table: "PairOfPlayers",
                column: "PlayerInfo1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PairOfPlayers_PlayerInfo2Id",
                table: "PairOfPlayers",
                column: "PlayerInfo2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PairOfPlayers_PlayerInfo_PlayerInfo1Id",
                table: "PairOfPlayers",
                column: "PlayerInfo1Id",
                principalTable: "PlayerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PairOfPlayers_PlayerInfo_PlayerInfo2Id",
                table: "PairOfPlayers",
                column: "PlayerInfo2Id",
                principalTable: "PlayerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PairOfPlayers_PlayerInfo_PlayerInfo1Id",
                table: "PairOfPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PairOfPlayers_PlayerInfo_PlayerInfo2Id",
                table: "PairOfPlayers");

            migrationBuilder.DropIndex(
                name: "IX_PairOfPlayers_PlayerInfo1Id",
                table: "PairOfPlayers");

            migrationBuilder.DropIndex(
                name: "IX_PairOfPlayers_PlayerInfo2Id",
                table: "PairOfPlayers");

            migrationBuilder.DropColumn(
                name: "PlayerInfo1Id",
                table: "PairOfPlayers");

            migrationBuilder.DropColumn(
                name: "PlayerInfo2Id",
                table: "PairOfPlayers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "354c5b95-5d6f-4b67-ac6c-8a924a6e4cfa", "AQAAAAIAAYagAAAAEDx6SEvm49LQH2i4ZB/GghRAqGaVaLrc+2lBsvrtdbSXr5rw+4zkNh+w3/t/P/xOrA==", "81d302b8-e06e-4bf9-96a5-fc65f222c92e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1bbf0fb-70c9-41f1-82d6-e5953eac7884", "7da2e4c9-db4c-44de-8ffc-ad23bf114830" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "061f5d85-9023-4cf3-821a-40506ddc3f4d", "8c316bc5-d1b3-4a49-a51f-10cfaf10965f" });
        }
    }
}

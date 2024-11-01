using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class addDbSetPowerCardPower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPower_Cards_CardId",
                table: "CardPower");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPower_Power_PowerId",
                table: "CardPower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Power",
                table: "Power");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardPower",
                table: "CardPower");

            migrationBuilder.RenameTable(
                name: "Power",
                newName: "Powers");

            migrationBuilder.RenameTable(
                name: "CardPower",
                newName: "CardPowers");

            migrationBuilder.RenameIndex(
                name: "IX_CardPower_PowerId",
                table: "CardPowers",
                newName: "IX_CardPowers_PowerId");

            migrationBuilder.RenameIndex(
                name: "IX_CardPower_CardId",
                table: "CardPowers",
                newName: "IX_CardPowers_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Powers",
                table: "Powers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardPowers",
                table: "CardPowers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03ee9665-b72c-4d4d-8c08-aa8f32a97a79", "AQAAAAIAAYagAAAAEOgQFFVdbUo2LsG2tdSN7W14pihoepJkEBXNbbb68sJKEWWkA/NUsCK3Ho7GXDsIhA==", "6a6f64c6-76e6-4e02-905a-e13ff99d6426" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3521f51-26cd-4f38-8638-9c960eb63ec8", "0cd4cdf1-663c-47a3-8901-aa01f8b52e8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56c84304-f08d-40dd-8349-253b76a06e80", "3b40423b-5862-4e9a-bdd8-fc365cd83e52" });

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Powers",
                table: "Powers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardPowers",
                table: "CardPowers");

            migrationBuilder.RenameTable(
                name: "Powers",
                newName: "Power");

            migrationBuilder.RenameTable(
                name: "CardPowers",
                newName: "CardPower");

            migrationBuilder.RenameIndex(
                name: "IX_CardPowers_PowerId",
                table: "CardPower",
                newName: "IX_CardPower_PowerId");

            migrationBuilder.RenameIndex(
                name: "IX_CardPowers_CardId",
                table: "CardPower",
                newName: "IX_CardPower_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Power",
                table: "Power",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardPower",
                table: "CardPower",
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
                name: "FK_CardPower_Cards_CardId",
                table: "CardPower",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardPower_Power_PowerId",
                table: "CardPower",
                column: "PowerId",
                principalTable: "Power",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

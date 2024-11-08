using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class add_CardPower_dbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPower_Cards_CardId",
                table: "CardPower");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPower_Powers_PowerId",
                table: "CardPower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardPower",
                table: "CardPower");

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
                name: "PK_CardPowers",
                table: "CardPowers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "944ee9b4-f9e7-4d70-8042-97d1ecaaf0e8", "AQAAAAIAAYagAAAAEFyQk00WIpqXlYll2+kQOYFL1YtcAeFMAS1mRWrbUYl+CIlufMWCEXAePQUEfIHziw==", "b58e6f80-e073-491b-9638-84130ad90b02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8092be8-b1ca-48a5-b926-c352d775f061", "4ce21611-e7ca-462a-90ca-bd432e7d32df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf31bd2a-9bc9-44db-9a51-d4c959c21400", "527898dc-57b4-45bc-a67e-80540aa394a2" });

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
                name: "PK_CardPowers",
                table: "CardPowers");

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
                name: "PK_CardPower",
                table: "CardPower",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3145ac6e-dcec-46a5-b1ad-47743acc5802", "AQAAAAIAAYagAAAAEEi5uw6BxXKHDjlnPXG1Rv3u0dnjic2s8EPztMDposSUCHf5aPNfwX9W+8YXiz5XOw==", "073e7ea7-c528-40f3-b461-b85cb473d5ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b2d6d23-88e2-49d9-b67e-16ed1e25024c", "799da957-9a39-4845-8032-a0a535b89741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b4f8b1c3-80e8-4608-9427-9a9680517b05", "7f13934a-f9d5-42cc-8453-ae0373946dd0" });

            migrationBuilder.AddForeignKey(
                name: "FK_CardPower_Cards_CardId",
                table: "CardPower",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardPower_Powers_PowerId",
                table: "CardPower",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

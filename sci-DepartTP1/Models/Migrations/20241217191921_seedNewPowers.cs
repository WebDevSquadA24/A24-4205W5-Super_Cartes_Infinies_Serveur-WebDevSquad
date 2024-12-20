using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedNewPowers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCardStatus_Status_StatusId",
                table: "PlayableCardStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.AddColumn<bool>(
                name: "IsSpell",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e801e1b0-8f9f-4d5a-9cea-936ce0b47a23", "AQAAAAIAAYagAAAAEOhtBsj21kmtgHeNumcluQrlidQIawJbzgrf48NBpcXYGonzDKmoOYZX8T11k7SQNQ==", "f8691a3f-aa19-4660-929c-e4dd91054ebd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d109fdac-1d15-4798-9f74-f01e2fad0350", "5d9e4c91-c242-439a-88cf-7669958a1953" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "763f4ae6-9a26-40a2-9ae7-528197288c04", "6a3031c3-4eb3-4cec-83ce-7176daa1584a" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsSpell",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsSpell",
                value: false);

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "IsSpell", "Name", "Rarity" },
                values: new object[,]
                {
                    { 12, 2, 4, 2, "https://i.postimg.cc/T2bh72HY/22bea6bc-8d68-4e72-b430-4e88024a8598.webp", false, "Chat Taser", 1 },
                    { 13, 0, 2, 0, "https://cff2.earth.com/uploads/2017/07/07123224/shutterstock_26373901.jpg", true, "Earthquake", 0 },
                    { 14, 0, 2, 0, "https://bigamartusax.s3-accelerate.amazonaws.com/2020/07/610KiaitzbL._AC_SL1024_.jpg", true, "Random Pain", 1 },
                    { 15, 0, 3, 1, "https://ideogram.ai/assets/image/lossless/response/uHbM6hlWRti8ou3OBwwnMw", false, "Chat Taliban", 3 }
                });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "NbMaxCard",
                value: 12);

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Description", "IconURL", "Name" },
                values: new object[,]
                {
                    { 5, "inverse l'attaque et la défense de toutes les cartes en jeu", "fas fa-random", "Chaos" },
                    { 6, "ajoute une valeur de poison à la carte attaquée", "fas fa-skull-crossbones", "Poison" },
                    { 7, "empêche une carte d’agir pendant son activation durant X tours", "fas fa-ban", "Stun" },
                    { 8, "fait X dégâts à TOUTES les cartes en jeu", "fas fa-mountain", "Eartquake" },
                    { 9, "fait 1 à 6 de dégâts à une carte adverse", "fas fa-dice", "Random Pain" },
                    { 10, "dès que cette carte attaque, elle meurt et tue la carte attaqué", "fas fa-bomb", "Taliban" }
                });

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 5,
                column: "CardId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 8,
                column: "CardId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 9,
                column: "CardId",
                value: 12);

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Description", "IconUrl", "Name" },
                values: new object[,]
                {
                    { 1, "La carte prend X dégats à chaque tours", "fas fa-skull-crossbones", "Poisonned" },
                    { 2, "La carte ne peut pas jouer pour X tours", "fas fa-ban", "Stunned" }
                });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "Id", "CardId", "PowerId", "Value" },
                values: new object[,]
                {
                    { 8, 4, 5, 0 },
                    { 9, 6, 6, 1 },
                    { 10, 12, 7, 2 },
                    { 11, 13, 8, 3 },
                    { 12, 14, 9, 0 },
                    { 13, 15, 10, 0 }
                });

            migrationBuilder.InsertData(
                table: "StarterCards",
                columns: new[] { "Id", "CardId" },
                values: new object[,]
                {
                    { 10, 13 },
                    { 11, 14 },
                    { 12, 15 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCardStatus_Statuses_StatusId",
                table: "PlayableCardStatus",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCardStatus_Statuses_StatusId",
                table: "PlayableCardStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IsSpell",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7088b879-b8a4-4bdd-86cf-ef2225625625", "AQAAAAIAAYagAAAAEO0z1v6Pt32b/qMy7mgxV9aOg2Oe486uZmPeCkZyjJtXBV+7SINkmAISBhHkxeCyPA==", "8dc13d2d-3fd8-4e81-b94e-68dcd7079514" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "508adccd-56c1-48cb-befc-ca4f5bbb779e", "7f4ca70b-0fcd-4bf3-bcf3-3d23e32af395" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d6bda682-d1a2-481a-a6db-15ab9ba38387", "845737b6-77b0-4925-9aad-c6c57c6adae2" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "NbMaxCard",
                value: 8);

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 5,
                column: "CardId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 8,
                column: "CardId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StarterCards",
                keyColumn: "Id",
                keyValue: 9,
                column: "CardId",
                value: 6);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCardStatus_Status_StatusId",
                table: "PlayableCardStatus",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

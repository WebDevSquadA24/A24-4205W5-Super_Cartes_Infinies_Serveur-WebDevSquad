using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementSeedProbability_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Probability_Packs_PackId",
                table: "Probability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Probability",
                table: "Probability");

            migrationBuilder.RenameTable(
                name: "Probability",
                newName: "Probabilities");

            migrationBuilder.RenameIndex(
                name: "IX_Probability_PackId",
                table: "Probabilities",
                newName: "IX_Probabilities_PackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Probabilities",
                table: "Probabilities",
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

            migrationBuilder.InsertData(
                table: "Probabilities",
                columns: new[] { "Id", "BaseQty", "PackId", "Rarity", "Value" },
                values: new object[,]
                {
                    { 1, 0, 1, 0, 0.69999999999999996 },
                    { 2, 0, 1, 1, 0.29999999999999999 },
                    { 3, 0, 2, 0, 0.59999999999999998 },
                    { 4, 1, 2, 1, 0.29999999999999999 },
                    { 5, 0, 2, 2, 0.10000000000000001 },
                    { 6, 0, 2, 3, 0.20000000000000001 },
                    { 7, 0, 3, 1, 0.65000000000000002 },
                    { 8, 1, 3, 2, 0.25 },
                    { 9, 0, 3, 3, 0.10000000000000001 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Probabilities_Packs_PackId",
                table: "Probabilities",
                column: "PackId",
                principalTable: "Packs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Probabilities_Packs_PackId",
                table: "Probabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Probabilities",
                table: "Probabilities");

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Probabilities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameTable(
                name: "Probabilities",
                newName: "Probability");

            migrationBuilder.RenameIndex(
                name: "IX_Probabilities_PackId",
                table: "Probability",
                newName: "IX_Probability_PackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Probability",
                table: "Probability",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53d7ad62-38de-4200-97b6-0a9979c981a1", "AQAAAAIAAYagAAAAEAlfB7rxwwBZTqoPly4+MUiFsO5Kk9ylTZpZTVQPACVBrr4x8TG6Jt+OJw8q0Kjeiw==", "ef7a4fa6-1bbf-4eaf-97cc-62c6f4f35960" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11181b06-cfc3-4616-ade6-c4c064333107", "6c1098bf-c434-4e82-83e6-ea5a06629442" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c69c762e-95ca-40cb-8e16-0991fc3fa525", "9fa87280-84a2-4f29-a40f-8b441f7344cc" });

            migrationBuilder.AddForeignKey(
                name: "FK_Probability_Packs_PackId",
                table: "Probability",
                column: "PackId",
                principalTable: "Packs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

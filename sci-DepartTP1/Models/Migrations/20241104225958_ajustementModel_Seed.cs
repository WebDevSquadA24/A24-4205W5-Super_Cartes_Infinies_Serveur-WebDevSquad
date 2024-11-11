using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementModel_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbCards = table.Column<int>(type: "int", nullable: false),
                    DefaultRarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Probability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    BaseQty = table.Column<int>(type: "int", nullable: false),
                    PackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Probability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Probability_Packs_PackId",
                        column: x => x.PackId,
                        principalTable: "Packs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6495bb5d-1fb2-41db-81a8-fb7b44bd4439", "AQAAAAIAAYagAAAAEKyrui6bIcQrZJg4OnYmpXCZw182s/Vp+uDCJydjb3QkpUKgl8vjfyVSIei/JK42Uw==", "de9e67f9-f801-4760-a8f4-57532fd55269" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc4a1d8d-fdf6-42ce-b461-b85dd7c3b634", "f1bfd452-c12c-4695-9d32-e1913a2052c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d27aa68-286a-47d6-8988-ed2b7a86682e", "ac0adf9f-cd77-4fa9-83fe-2579f2099542" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoserMoney", "WinnerMoney" },
                values: new object[] { 50.0, 100.0 });

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "DefaultRarity", "ImageURL", "Name", "NbCards", "Price" },
                values: new object[,]
                {
                    { 1, 0, "https://th-thumbnailer.cdn-si-edu.com/3hb9uUW7hZHUXxJmBmfFkwkivJI=/fit-in/1600x0/https://tf-cmsv2-smithsonianmag-media.s3.amazonaws.com/filer/fd/e7/fde77fde-700d-4a08-8e19-305a0de60130/5879116857_4ab170f4d5_b.jpg", "Basic Pack", 3, 200.0 },
                    { 2, 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUe7jv0hsq3INvymTpQvP8F-TprBnerk4HGnyHKY5nFj1kXHEg", "Normal Pack", 4, 500.0 },
                    { 3, 1, "https://i.pinimg.com/474x/f8/39/37/f839377928c94ac922cc39f35fd0a841.jpg", "Super Pack", 5, 2000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Probability_PackId",
                table: "Probability",
                column: "PackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Probability");

            migrationBuilder.DropTable(
                name: "Packs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53368349-b382-4b78-aec3-d4ba15cf6993", "AQAAAAIAAYagAAAAELOxe5c0trX7p/YZhjVdeLgKvU47cRzkfux54p4kMg8C4eJkOBsOnO4+Er68LYpm/A==", "877b723d-42c7-4c50-a12b-12d266633bb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "da2e0812-6abf-4bcd-a420-5fc45121d2ff", "d3bce5a0-9c8b-43fb-82bd-780a12da96e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca9bd92d-706c-4ab9-9d4f-78ef00859cbe", "eb8984c6-52dc-461c-b972-7a4447f343d2" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoserMoney", "WinnerMoney" },
                values: new object[] { 10.0, 50.0 });
        }
    }
}

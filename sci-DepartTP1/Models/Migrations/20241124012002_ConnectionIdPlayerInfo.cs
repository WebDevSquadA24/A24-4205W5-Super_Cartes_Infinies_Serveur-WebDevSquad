using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionIdPlayerInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PairOfPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairOfPlayers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ELO = table.Column<int>(type: "int", nullable: false),
                    attente = table.Column<int>(type: "int", nullable: false),
                    ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInfo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de5a87f0-277d-492c-a386-aa67ba3fb3e6", "AQAAAAIAAYagAAAAELZzaIp6NYQj9WL4IEilF9ddQXivS55263QCt2UKeFtfueNStcLdLRyW58xuAH+Ayg==", "4ebbb12f-aca9-4f30-897b-54152de17c35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66653709-041f-4873-996d-aaccfca088b3", "7a65fb0b-2355-4455-a8d9-e334e77b08f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cbdd4d26-82a2-4369-a294-0303eb515347", "10cc6d0d-8b8b-4b06-a656-59e7a19f9439" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PairOfPlayers");

            migrationBuilder.DropTable(
                name: "PlayerInfo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05fc5dc3-40c5-4ecf-b888-fbb111966aba", "AQAAAAIAAYagAAAAELWyhCy35ELZhWYQUsLtxvdAryQnd0eWjxrTDthPlssZ8Dg4htV8jnYp0gdaAfqwVw==", "9f7504a6-5ec9-4e8a-8ea8-94ab6f6221a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff7ed78f-1911-4f22-a670-b0ab91c41020", "fe315e77-3c2a-4b26-9a84-dd491d9670d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20cdff51-0ebd-45d6-b2f8-9b77b404549a", "e05864c6-90fb-4888-8218-aa43416441bb" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class IndexBattleFieldIndexPlayable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "PlayableCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndexBattleField",
                table: "MatchPlayersData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c7a36c6-a203-4fd2-af5b-4be145dda61a", "AQAAAAIAAYagAAAAEGpRr6xXIVmroF9uZn02YohzVpNc/YXo3SW62T6LRhRcJ/5dUSOfEvHKfMP6H7yNbw==", "ea4d2ab5-39f3-4f13-97b8-b6559f769334" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4b6e7128-72ec-47bb-9edd-339977387ab6", "a38bf0a3-eda5-4469-ad01-3359d7884e50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7d84e95a-c89f-46d3-b09e-0b97b1c6271e", "7b648ca5-423e-4410-bd54-cad2882d517e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "PlayableCards");

            migrationBuilder.DropColumn(
                name: "IndexBattleField",
                table: "MatchPlayersData");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d61a38b-c643-4cfa-ac46-736cc4c08645", "AQAAAAIAAYagAAAAECML41+vdSBCYM5vl4ErqfnceoAaw1iq66i5DjyudewMymrqPyu6aVSDfI59uNIMcg==", "f4e65b1a-ec9d-43b5-b734-de736262706e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f697683a-d211-41ee-ac5b-1706c5a47ac6", "c6e5f55d-9dbe-46ca-bb69-b1b8eb9373e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf29491e-34bb-4cc6-939f-28ac7ef978b9", "4157d056-d3fb-4922-a7a7-dbd2f2401268" });
        }
    }
}

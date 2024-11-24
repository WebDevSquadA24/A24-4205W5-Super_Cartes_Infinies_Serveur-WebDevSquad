using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionIdPairOfPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherConnectionId",
                table: "PairOfPlayers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eaa054a-2435-4b29-b850-e3386e3c4afb", "AQAAAAIAAYagAAAAEIB/DLLIiPndgInipO7zpeAlgWpLpxzUKqFNFPLZcx1f4CNfAP4cPrBczg5GQ80lSQ==", "cb87092e-9ba0-43e0-a710-527b4f56e463" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1444214-74c4-4a53-b062-318047022268", "17e2ac27-de4c-45ca-b6df-8b074059e288" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "db7705a7-b79c-4e9f-a89b-ebf8ce61ba02", "0012e779-0b5b-42f6-973b-a0c276338f8f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherConnectionId",
                table: "PairOfPlayers");

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
    }
}

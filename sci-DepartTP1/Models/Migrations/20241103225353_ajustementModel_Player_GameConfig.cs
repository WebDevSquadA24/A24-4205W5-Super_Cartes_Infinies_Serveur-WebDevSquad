using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementModel_Player_GameConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BeginnerMoney",
                table: "GameConfigs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LoserMoney",
                table: "GameConfigs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WinnerMoney",
                table: "GameConfigs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                columns: new[] { "BeginnerMoney", "LoserMoney", "WinnerMoney" },
                values: new object[] { 1000.0, 10.0, 50.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginnerMoney",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "LoserMoney",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "WinnerMoney",
                table: "GameConfigs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0693e469-aeec-4183-b9a6-fa170b5f78e4", "AQAAAAIAAYagAAAAEL0zUqQTAyqk3kezPhm/NbcwhbEZ3icLAldtAQDQUlN2Bg9XiMT52Owk5V3vbtNZpg==", "7b6b7957-edd4-4b7a-a4cf-3d15759fff56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "28372af7-7ffd-41da-8df2-c3d21fa62253", "b6653607-b9f7-4b0a-8ff4-64858fdf7fa3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7997bf8-7bc9-4192-9737-0f29e3867e8b", "b63e125c-11cb-4d74-ade0-27ac47903446" });
        }
    }
}

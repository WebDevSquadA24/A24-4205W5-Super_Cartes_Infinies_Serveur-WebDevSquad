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
                name: "Money",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                values: new object[] { "859c0099-31c9-4e34-bf4f-ad9b8a7867ad", "AQAAAAIAAYagAAAAEFOzdLKJy91dEOmmoSxEDAgivLXcTlRumRET4yxFgJsJPl1lbQSCkuoRCzyPuYvRnQ==", "08514fbf-2f65-4e41-8e95-23dda3e4911d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ffd324f-24b0-4f7f-b9d4-10be7624c7bb", "868b6dba-3285-4e2d-a7e2-9ccd5a8d3774" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "df8bf2c1-5a0b-4654-a7f0-8ce7d6e0d8c0", "57221549-0d2d-4e33-acc9-88b71d30c191" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BeginnerMoney", "LoserMoney", "WinnerMoney" },
                values: new object[] { 1000.0, 10.0, 50.0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "Money",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "Money",
                value: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "Players");

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
                values: new object[] { "e165fffd-a888-4802-9ff9-5a900ae5f717", "AQAAAAIAAYagAAAAEPfPGcDwZDZ56UO/oxNMvKnGWRF/68wksKdDO02LIXzeLlVlp8kDJ8vs0UyfmHaODA==", "77011a50-1e27-4090-94be-dbb2f0771feb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6c8edf53-5366-4224-861d-eaca649da34d", "cd0b9bb4-8240-434a-b69f-6660d54d437a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6f38f16-d95d-4795-8cda-5478c8943fbd", "ede08510-5143-4236-a997-7bdea4fac7f8" });
        }
    }
}

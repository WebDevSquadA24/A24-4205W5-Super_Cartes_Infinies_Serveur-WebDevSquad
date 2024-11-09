using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementModelPlayer : Migration
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

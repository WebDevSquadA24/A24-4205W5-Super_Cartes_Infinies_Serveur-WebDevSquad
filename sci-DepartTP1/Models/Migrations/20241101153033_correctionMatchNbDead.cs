using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class correctionMatchNbDead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nbDead",
                table: "Matches");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nbDead",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e967845-c734-4a50-a226-962345b6ec3b", "AQAAAAIAAYagAAAAEN9cgeE7W3nreWVDR/9iw0SojKfpgoUBuEb50vdfwIEXRvwbJkHHPD1TEnL5P1EvJg==", "33930d50-cb20-440a-b49f-2131e10d5bf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "57376087-1851-49bc-85d0-9042f523a4db", "04d3fd3b-6b16-4d8c-9f20-2585909fd34a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e560c002-750a-4095-8822-b0c96ca5dde0", "bde73245-dc9a-4774-93ff-4692f23aec77" });
        }
    }
}

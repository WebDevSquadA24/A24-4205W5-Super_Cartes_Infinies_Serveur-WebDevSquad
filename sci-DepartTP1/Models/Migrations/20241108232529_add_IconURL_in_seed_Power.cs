using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class add_IconURL_in_seed_Power : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e70c1d0-dc70-4931-a009-335585807b72", "AQAAAAIAAYagAAAAEGqy7HA7djV6foU70w7jxPm4Tx+isw4Jifg0IvYXg8EzbQb75RFBJu7aBpE0df1QJA==", "f3a749b8-f2ea-4722-8839-e1410c788d54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2174a89c-3e69-4a77-9de0-8d4fd9d8ff0d", "1bf5ff2c-d40c-4766-bd05-14fe40db895c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "94cc000f-37e1-4ac1-b786-fad7514b68c9", "fccf1813-d937-4855-bd20-8e2f8d551cc6" });

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconURL",
                value: "fas fa-bolt");

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconURL",
                value: "fas fa-exclamation");

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconURL",
                value: "fas fa-heartbeat");

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "IconURL" },
                values: new object[] { "tant que la carte est sur le terrain son joueur gagne de la vie", "fas fa-cross" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "944ee9b4-f9e7-4d70-8042-97d1ecaaf0e8", "AQAAAAIAAYagAAAAEFyQk00WIpqXlYll2+kQOYFL1YtcAeFMAS1mRWrbUYl+CIlufMWCEXAePQUEfIHziw==", "b58e6f80-e073-491b-9638-84130ad90b02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8092be8-b1ca-48a5-b926-c352d775f061", "4ce21611-e7ca-462a-90ca-bd432e7d32df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf31bd2a-9bc9-44db-9a51-d4c959c21400", "527898dc-57b4-45bc-a67e-80540aa394a2" });

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "IconURL" },
                values: new object[] { "se sacrifie et les cartes alliées prennent aucun dégats pour ce tour)", null });
        }
    }
}

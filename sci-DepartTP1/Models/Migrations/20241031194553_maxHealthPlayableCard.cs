using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class maxHealthPlayableCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxHealth",
                table: "PlayableCards",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxHealth",
                table: "PlayableCards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3afdc419-a912-4413-8200-70df6d340852", "AQAAAAIAAYagAAAAEIMlJoNpk8YEer43D28uX/bzB1i1YA/t4KTpNTeqbJNcorBO6HFLYvS7EFcBhpbzoQ==", "9d197267-785e-43dc-abf2-e715aebca768" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7447d6a0-87c2-4762-8f6d-5a99364d7b20", "dc335cce-b1b0-4012-bf9d-177d505b9f06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "54b5a125-73cd-4137-8153-fc603c8b3686", "81b54757-4084-4eab-9f5c-5e927ccad912" });
        }
    }
}

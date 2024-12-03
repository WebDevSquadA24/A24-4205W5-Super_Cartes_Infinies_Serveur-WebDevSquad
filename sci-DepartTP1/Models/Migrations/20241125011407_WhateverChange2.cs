using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class WhateverChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "354c5b95-5d6f-4b67-ac6c-8a924a6e4cfa", "AQAAAAIAAYagAAAAEDx6SEvm49LQH2i4ZB/GghRAqGaVaLrc+2lBsvrtdbSXr5rw+4zkNh+w3/t/P/xOrA==", "81d302b8-e06e-4bf9-96a5-fc65f222c92e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1bbf0fb-70c9-41f1-82d6-e5953eac7884", "7da2e4c9-db4c-44de-8ffc-ad23bf114830" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "061f5d85-9023-4cf3-821a-40506ddc3f4d", "8c316bc5-d1b3-4a49-a51f-10cfaf10965f" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "ELO",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "ELO",
                value: 1000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85ae56e1-3b4b-487b-8226-75607fcc1795", "AQAAAAIAAYagAAAAEK2CeqwI5D5meCBr0+Vhuz0lRQoOf75UQHgpcvir/QT2KAOkJH9UWvl9G5HuyaEQSQ==", "6df8fd45-5b98-452f-8646-83103c4c5811" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4f082d6d-2bd3-467e-9fb8-4b324f2d2567", "ab0cf79b-5461-45cc-9393-41058e374f5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ae3ca4e-16cd-4a69-a689-4e57a62de1e5", "f8c20e31-3059-4f56-b3aa-f6eeceee2693" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "ELO",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "ELO",
                value: 0);
        }
    }
}

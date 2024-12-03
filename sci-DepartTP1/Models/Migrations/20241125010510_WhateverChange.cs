using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class WhateverChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ELO",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ELO",
                table: "Players");

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
    }
}

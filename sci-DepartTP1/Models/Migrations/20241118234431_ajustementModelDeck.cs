using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementModelDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbDefeats",
                table: "Deck",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbVictories",
                table: "Deck",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b567d2c-5457-4ad1-8a57-5d6f7f610d4f", "AQAAAAIAAYagAAAAEHxYc7sz87W31OsIUWrjr8zWVYaLnHt4r7za7EgGT3Iv9zZdVi4qP5PyTktpB8FdFA==", "3508ef99-6fd5-4554-a4ac-20fc7615b66b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f738fc5-9ddc-424c-8560-632592b7ea8f", "44f546f6-dd69-4770-8973-14b8f6262307" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "173fc7c3-7cac-4d96-9ae0-6f1bd2e9441d", "507b6d03-7b4e-4e71-b4ff-8efb79b4fedd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbDefeats",
                table: "Deck");

            migrationBuilder.DropColumn(
                name: "NbVictories",
                table: "Deck");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88ba81dc-a629-4534-a69a-cd4b63f32c51", "AQAAAAIAAYagAAAAEJS8BMkv6lCbSLZWizuBXyEWRoiDS8N0E13em6TMy0docN2kwfXyePQRk3DasiKrGg==", "6535b4dd-cab2-4c77-842d-dc69ee0c5aa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3061398e-8934-4274-91e3-1256c2e15e36", "bf77b611-adb0-4f45-8670-ed976182c80d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a11a1551-2b42-4608-9047-b6a9cccb79a0", "6696321f-d943-46a6-8670-b4022629a142" });
        }
    }
}

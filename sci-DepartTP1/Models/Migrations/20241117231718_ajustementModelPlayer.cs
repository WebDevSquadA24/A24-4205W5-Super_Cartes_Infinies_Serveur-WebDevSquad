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
            migrationBuilder.AddColumn<int>(
                name: "NbDefeats",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbVictories",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NbDefeats", "NbVictories" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NbDefeats", "NbVictories" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbDefeats",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "NbVictories",
                table: "Players");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7088b879-b8a4-4bdd-86cf-ef2225625625", "AQAAAAIAAYagAAAAEO0z1v6Pt32b/qMy7mgxV9aOg2Oe486uZmPeCkZyjJtXBV+7SINkmAISBhHkxeCyPA==", "8dc13d2d-3fd8-4e81-b94e-68dcd7079514" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "508adccd-56c1-48cb-befc-ca4f5bbb779e", "7f4ca70b-0fcd-4bf3-bcf3-3d23e32af395" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d6bda682-d1a2-481a-a6db-15ab9ba38387", "845737b6-77b0-4925-9aad-c6c57c6adae2" });
        }
    }
}

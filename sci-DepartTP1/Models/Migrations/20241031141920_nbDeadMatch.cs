using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class nbDeadMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nbDead",
                table: "Matches");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03ee9665-b72c-4d4d-8c08-aa8f32a97a79", "AQAAAAIAAYagAAAAEOgQFFVdbUo2LsG2tdSN7W14pihoepJkEBXNbbb68sJKEWWkA/NUsCK3Ho7GXDsIhA==", "6a6f64c6-76e6-4e02-905a-e13ff99d6426" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3521f51-26cd-4f38-8638-9c960eb63ec8", "0cd4cdf1-663c-47a3-8901-aa01f8b52e8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56c84304-f08d-40dd-8349-253b76a06e80", "3b40423b-5862-4e9a-bdd8-fc365cd83e52" });
        }
    }
}

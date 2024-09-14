using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class creationStartedCardEtGameConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3166ee8-bd73-418c-811b-e554e37a8079", "AQAAAAIAAYagAAAAEM6lGKZlJg36nlO8hGsw7V9HrtyKGfbu3f3ajQhsKDIfnskGDBOls/QjGL9KfP78jg==", "80709887-bb99-4d89-9b45-f9e6d08b6bf4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a67ad746-a99b-4360-b5b9-6308eb13e297", "74d6b510-b143-4148-bde6-d23b43b172a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8beaeed6-4601-43b1-9f01-3defaee88009", "b5ef1e36-9141-4177-a6f2-6c311a6fc30e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a8cb505-c286-49ea-b2c1-d3970a791fcf", "AQAAAAIAAYagAAAAECi3WHFUt7MBCqKF3CnjMNyywKHZcr/TpXd32saRCqx8xcaDpoE6xjOZHY0a0CCtlw==", "00529dbf-5231-4890-a50d-21125e3ecf4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7e01982d-3940-4c37-9133-645693588575", "19060b2d-35b6-4792-9db6-3a4cb5c6955f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "06afa481-b777-40dd-bbf1-bf43a2f7ee5a", "ce1857e9-604e-4adc-93cc-02b7eb2ee061" });
        }
    }
}

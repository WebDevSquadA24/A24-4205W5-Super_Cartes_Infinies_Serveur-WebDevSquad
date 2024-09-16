using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class initiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f5a7ff2-412f-4321-a3bf-9082b7e30773", "AQAAAAIAAYagAAAAEH0JnETUr8xHs9nxFpL9I31c+zI+u9L0FjPezvaoNeQvlE5Y8yVkm0SDlhsz/QMYdQ==", "13da33e1-37c3-4947-bfc5-dea963607901" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c2fb6c5d-d929-49d1-b7dc-15915f12f400", "1154ef34-bfb8-4065-9e7c-7485055966bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "09caa6d1-e5bd-4f68-935f-f9259cf24d39", "1c4ea080-11b1-4c04-8af1-c3d7bcd5f075" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "103c3768-b27a-47b6-ad90-ad9a1d5cd83f", "AQAAAAIAAYagAAAAEEI+hKQSBUAcj5purBBSS7jBDh+XFrVY+bwx8HXRTeVlurydGebkn9cLxXoMSuRaHw==", "8fa9d570-c1bf-4132-a8f1-c53d98ec4106" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6d33746f-98ba-45ad-ac92-ddd4cdbd60d8", "43a469de-fb90-461c-ab1d-a2c217938d6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef2559aa-44ab-4e26-ab30-5d3a9be23bb5", "68d790d0-d211-4a01-bf43-1f161bbbb72d" });
        }
    }
}

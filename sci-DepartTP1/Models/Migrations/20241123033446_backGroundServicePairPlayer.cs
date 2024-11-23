using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class backGroundServicePairPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05fc5dc3-40c5-4ecf-b888-fbb111966aba", "AQAAAAIAAYagAAAAELWyhCy35ELZhWYQUsLtxvdAryQnd0eWjxrTDthPlssZ8Dg4htV8jnYp0gdaAfqwVw==", "9f7504a6-5ec9-4e8a-8ea8-94ab6f6221a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff7ed78f-1911-4f22-a670-b0ab91c41020", "fe315e77-3c2a-4b26-9a84-dd491d9670d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20cdff51-0ebd-45d6-b2f8-9b77b404549a", "e05864c6-90fb-4888-8218-aa43416441bb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

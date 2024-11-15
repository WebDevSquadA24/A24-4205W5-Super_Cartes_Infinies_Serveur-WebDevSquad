using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ajustementSeedProbability_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53d7ad62-38de-4200-97b6-0a9979c981a1", "AQAAAAIAAYagAAAAEAlfB7rxwwBZTqoPly4+MUiFsO5Kk9ylTZpZTVQPACVBrr4x8TG6Jt+OJw8q0Kjeiw==", "ef7a4fa6-1bbf-4eaf-97cc-62c6f4f35960" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11181b06-cfc3-4616-ade6-c4c064333107", "6c1098bf-c434-4e82-83e6-ea5a06629442" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c69c762e-95ca-40cb-8e16-0991fc3fa525", "9fa87280-84a2-4f29-a40f-8b441f7344cc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d35b136-94ab-4c2d-9fd0-dc738576f576", "AQAAAAIAAYagAAAAEFplf3pRnm7sxuJnwfUU/6pOEmJtvyGAPxvKfE52qdjSKfkm3ffJJdH9xnpqRBcbRQ==", "27747964-787b-4f4b-9c61-088a39bdd423" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78a7b9b0-01c1-46c5-b26e-61e38f21aeb7", "5100384b-7b62-4fed-9710-1b6806dcdd82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0b2f7673-6d5f-4e32-99c1-81d2b384fae5", "f371f3e6-a5ea-464e-9f8e-54e0d46d9914" });
        }
    }
}

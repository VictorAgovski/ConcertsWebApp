using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class UpdatedRestrictions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14edcfea-f670-44b8-ad85-e04a1457eb79", "AQAAAAEAACcQAAAAEBxvfGlTPPhjZ7I3FLCkS/VPXx7VX9Ys7sHyGC7pwIgGZvpq/MU9fel/NA3KfqMRLA==", "89c65581-8a07-401d-99b5-e2f7d156952a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cef60f38-e20a-46d5-807e-23d29e805fc3", "AQAAAAEAACcQAAAAEE/zoogZL2AYVCE0xkWbAbRax2ePgk40ycpgesicsj+4lcsuLREdH5lQ1GQF/o8Fig==", "3c2764a1-f012-414e-b081-ea851d2337d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39b8d1e3-481c-4d2c-bfdd-514122bc1bbc", "AQAAAAEAACcQAAAAEJOAlNsdNk4AjmPK0CGE/05r2MqBX7PFZeHvO4eOU4Uw8MJEMx4YdTYOxQ0CWorfKA==", "c458b960-6ab8-4b97-be2e-c1cd23332be5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69002780-0c6d-47b0-a4ec-2fb981206771", "AQAAAAEAACcQAAAAEMK0ugszICSqXg656cn/1QomtVYt8HZc33gu6Ak6wGCHAfgWeMv08Cecwq9Y7mu6pQ==", "30bff93d-d022-4c32-84f9-14e8fbf9a138" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ca02806-ab57-4b4c-bde8-139d665a34b8", "AQAAAAEAACcQAAAAEBADCe1ZFie/Q9SCxHSbVj/05OqAiwENCLWnowiWZDNWZ2iIaI2TTBe8V0kS1CDDng==", "f5f069ed-ce19-4e97-a71c-fff6b3fb7ef0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e804688-d2f4-4d7b-8331-46b2fd3ad5f1", "AQAAAAEAACcQAAAAEAL28SevMj7duRoaA4ZHY55Ci/Z4E9e0/DbuTZvA8JcBdhF1eCxPXDp5v5X6pTQZkQ==", "bb2ed9c4-4c68-4478-966f-77e7b6754fbd" });
        }
    }
}

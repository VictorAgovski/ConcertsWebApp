using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class UpdatedRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4313cb7-df61-4bce-86e5-3543133dd1ce", "AQAAAAEAACcQAAAAENlTfSnufT7aUMy0aznW8BzoWeviVCkk3eZIuOjF7Ux2p8NdVLyIjassSxCyiqHzfg==", "61aa5edf-f8c9-414e-8477-af75b8beb214" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "690ece05-2854-44bb-86ec-d48128cc1e4e", "AQAAAAEAACcQAAAAEB00ZgYUh+NI7RCpUjElJi46mdIi21V6gQxbUrRgV19/PeqqzyrsUvlJJOOfQrU/yQ==", "8c1969c5-f081-4772-969d-fe750121b00f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a7d2b75-3a32-4acd-9895-8b45c726c8f5", "AQAAAAEAACcQAAAAEOkTjvu3sjMICeAM7pFfi4RYMAnP11pErBf0/x4VY2NBMtEbNj6ydx0WXFZWpxFliQ==", "8754c3a0-713d-48cd-9ddd-e29551200ff7" });
        }
    }
}

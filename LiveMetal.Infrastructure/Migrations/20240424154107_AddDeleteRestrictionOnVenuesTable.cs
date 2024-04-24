using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class AddDeleteRestrictionOnVenuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52b2e5d5-fe56-4597-af84-53c550d28843", "AQAAAAEAACcQAAAAEPRWA7bsvgbQKuFF2WcmWSMRgx+U2r3JjaXhAOWty7cbJNFm0Ty9gvbMFD2zRLl+tg==", "8bc10d67-44c9-4c9a-9786-b7a07134b55d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9154dfa3-7ccf-4dea-9610-9db616452f57", "AQAAAAEAACcQAAAAEEvg1WQ/aRwnuJXbAtIY338HqZPy7uH2279550TIBo37io8Gk5d60nxUIHesUKsB3Q==", "8ee36eea-7612-476e-8ce8-ac8b3a53e51f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abe259b4-e0ed-47b3-abe7-85262cca4ac2", "AQAAAAEAACcQAAAAEGSGKlcqqLRKyJdK3/i6MMXdbOR3qFeeqJ1o08l+wDykebbrxIQYWVBqZNTUFXqUTg==", "0d0edd02-fc5c-4a71-be50-0955d7781316" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class AddedRestrictionOnDeletions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavourites_Bands_BandId",
                table: "UsersFavourites");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavourites_Bands_BandId",
                table: "UsersFavourites",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavourites_Bands_BandId",
                table: "UsersFavourites");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cd67cc4-edd6-4bd7-a3ae-95885f03c76f", "AQAAAAEAACcQAAAAECIOxOScpjNvcmpfcRVMWxAQRN410y9jIdDa1zZeDD5O+XefTmZnx+dbAL2Tohlrxg==", "5c5512b6-f9e2-4fcf-8323-d795b84ce597" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8788821b-e6e1-4c45-836d-9e715cc1af54", "AQAAAAEAACcQAAAAEIJH8HEnUrYv4N5zpwaWumPp+44cf7FKk9t1XWC/QS0ZRlpxx4j3gOlyDSsyC96l8Q==", "c011f222-b984-47ab-8de9-ea40e68383f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3c1614c-079d-46ac-af2c-e266fa84d0a4", "AQAAAAEAACcQAAAAEAUDxki9oPikqZEKuHwz46Kn5Kva9MO5EbU9jUIz/orU5aWQ7olzJTF2SF77bfzLNw==", "d29017df-80ae-444c-9915-166ea51fc138" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavourites_Bands_BandId",
                table: "UsersFavourites",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

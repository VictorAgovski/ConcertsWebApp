using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class AddOneMoreReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f8cf489-c1b3-4777-b906-77eb523a9b20", "AQAAAAEAACcQAAAAEEwfOO2istEsN+AQsK4mTi3MvcHVk1Hm1WqoU+bF+GDs1Yru+tYQwHYafvybWvU3Eg==", "bcd059fc-9264-4749-b6d2-a9e2becf3100" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bbea381-9702-441f-a769-f60ce391c450", "AQAAAAEAACcQAAAAEAFG/ts9SGvrPaN4Qp7r65OIYYIqUAMfeBrg9XS6iAAI7myxCwi8SsfgljyQqowA/g==", "4470d047-bffa-4243-a057-b5e47d142073" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f13d9cb5-5f80-44a7-b29b-d834919434eb", "AQAAAAEAACcQAAAAEB7lBc+MjLDx4WqzsTIXzn2ngVy9y1hX5bMrSvbLSBtqN6ro6pEtCxotSMMJCWC4sg==", "0e50bfd7-1a7c-4cac-98ed-ec8df9dcd20e" });

            migrationBuilder.UpdateData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 3,
                column: "BandImageUrl",
                value: "https://deadrhetoric.com/wp-content/uploads/2015/08/nile-band-2015.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1adec321-0e0c-4166-8088-6bbc2cafa560", "AQAAAAEAACcQAAAAEN9Mmv5yEp7sF0Fo63eIE5fC+Bh5vnH70KbFujMhozh2PQTPf2WunkfRcY0KaiDupw==", "9133152c-5caf-4dda-9a04-d75f4e78fa5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31b6f055-cbb3-4da1-883d-7e462e4617b0", "AQAAAAEAACcQAAAAEChGaYYEbO5BvEb1ymeNSfPw2WMX02QtPjJOeJ0t+67lVECpz05AIIoGBX9gIzPxVw==", "f10f67b2-3371-44ed-b098-b3f0c6e5fedd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11585dc2-f99b-4c1f-928b-3b256dc4d0a1", "AQAAAAEAACcQAAAAEAsr8X/QTwonesTFXF/pcESpfijnCJ62Q2dYceiAalQXqYP3avEPGDvnErP9/yypgw==", "64069e82-fae8-4bf9-857a-8654b01d4692" });

            migrationBuilder.UpdateData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 3,
                column: "BandImageUrl",
                value: "https://static.wikia.nocookie.net/logopedia/images/6/6f/Nileband_logo.jpg/revision/latest?cb=20160624042213");
        }
    }
}

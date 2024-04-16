using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class AddImageUrlToNewsAndDbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "News image URL");

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
                table: "News",
                keyColumn: "NewsId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://pbs.twimg.com/media/FwBzG3UXgAARJAW.jpg:large");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewsId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.rollingstone.com/wp-content/uploads/2023/07/new-Metallica-theatrical-trailer.jpg");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewsId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://label.napalmrecords.com/images/bands/nile/2021-nile-band-picture-press.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fd444bb-9ce5-4659-b9fa-39c940ccf327", "AQAAAAEAACcQAAAAEK4VWQ2gU2rpMENEifI8kGd//kTHh9XDj4aswJn6FLFoXGVSQNX1P5PbrfMdz7zLRg==", "2f249b20-305b-4e39-af34-00d97d205d4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab4f7eb-404c-48d5-981e-e6f284ff8398", "AQAAAAEAACcQAAAAEC5C/uSr7O4vHivDAZ/P6CvJseuxM4BWKy/Zy48V68xI2SzcgLbKmL42n5NyR50cRQ==", "5d471cfb-16da-4047-9d29-fd66b6609382" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aec58dc4-1d47-483b-a1fe-00727bb26450", "AQAAAAEAACcQAAAAEJHOvhcEtnpBWhxLAmH4HsBip+Bl3ZeukzIeuyqSdleCKiRpbgWZZKR49/hvwW2+Zw==", "5791b109-679d-4807-9764-81a71943fbb1" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class NewsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bands_BandId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ConcertId",
                table: "Reviews",
                type: "int",
                nullable: true,
                comment: "Concert unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Concert unique identifier - foreign key");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Reviews",
                type: "int",
                nullable: true,
                comment: "Band unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Band unique identifier - foreign key");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false, comment: "News unique identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "News title"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "News content"),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "News publication date"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User unique identifier - foreign key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_News_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "News Information");

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

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "NewsId", "Content", "PublishedOn", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Iron Maiden have announced that they are working on a new album. The band's bassist and primary songwriter Steve Harris has revealed that the new album will be released in 2023.", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iron Maiden announce new album!", "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" },
                    { 2, "Metallica have announced that they are releasing a new single. The band's drummer Lars Ulrich has revealed that the new single will be released in 2023.", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metallica to release new single!", "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" },
                    { 3, "Nile have announced that they are embarking on a European tour. The band's guitarist Karl Sanders has revealed that the tour will start in 2023.", new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nile to embark on European tour!", "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bands_BandId",
                table: "Reviews",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bands_BandId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.AlterColumn<int>(
                name: "ConcertId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Concert unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Concert unique identifier - foreign key");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Band unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Band unique identifier - foreign key");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5bc90a9-092d-4744-9404-526e24fa9341", "AQAAAAEAACcQAAAAEPLw2Hb5TOk4GPnG3Y85/Up3l4i8jMNiO2DV+o9N8pv1YC7CqljIYFcTKdYn3GbUXA==", "ca77170d-5442-4b10-84b9-dcdaf89d0862" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f0dd8bb-9567-4f8f-9828-c44649fd6e85", "AQAAAAEAACcQAAAAECCCAFLD03D+p3XbuD2XFbVU3gKlRBSqgCmL6FBZpM/SMPuxC6I+2v308mNuCB/dKw==", "7ae0ebc4-bdb9-450a-8aec-06409f029cfb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94ef8137-086e-4a67-8d7e-07546c26ce2d", "AQAAAAEAACcQAAAAEL4cZKz9WwZkEvESf4CcoUD1TNLLpdT2n932aQDBcHizX9aCLCR8MQYZKuekzefeEA==", "16a582da-019b-4ce5-8a6c-fc977f6ed5ea" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bands_BandId",
                table: "Reviews",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

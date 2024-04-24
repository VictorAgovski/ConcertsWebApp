using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class DeletedUserFavouritesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersFavourites");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76e6dbae-dfdc-4883-aa78-50885b4f8ee3", "AQAAAAEAACcQAAAAEJ/dtaB0H3wsZw4z71vg0QxVXX1cbYjZ4Sv4aJNp/PqOGVoZhWg076X/JyT0v8FKhQ==", "5966825c-61c9-4a5e-8bda-266aad1be969" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e7af81a-81d4-4bc3-988a-63de57b10b93", "AQAAAAEAACcQAAAAEC+qEyDovPpE4sZ6oXDDP21AfdFNGq3EZEoeS9oaAcy9TD4d55RZNC0wYb9c1GpQGQ==", "31459021-44fc-4339-9b97-3def3bcdee49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e240d882-f73d-4e09-99e4-04c559b3207b", "AQAAAAEAACcQAAAAEBHkjQ+tVSP8HY+I0Qy57lw9pvwth8Psd3aOr96zJr/EM2TVjD9gZxGosjYPs32nGQ==", "ffc5de2a-14c4-4b4c-873c-1fd355e29c9c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersFavourites",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User unique identifier"),
                    BandId = table.Column<int>(type: "int", nullable: false, comment: "Band unique identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFavourites", x => new { x.UserId, x.BandId });
                    table.ForeignKey(
                        name: "FK_UsersFavourites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersFavourites_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User Favourite Bands");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e83a8fa-dc21-4d6d-bfca-f6fde7b95e13", "AQAAAAEAACcQAAAAEKpNX39RHSesNZp60HDQ/qCTDYpxb4TnFMslsY5ih6cImB3zeWKx4rv56er3UyGaGQ==", "59ebdd3b-7f86-40f1-89cb-65fb7253c44f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce3b4381-47c1-48bd-96cf-d3a6162588e9", "AQAAAAEAACcQAAAAEN3+tOOSwu/M41tMtoH7CkeQ/6i3uPUP5R+yHYuQkArPX6wMlGtedyLmWP5gN1U82A==", "3d1f9206-7ce0-4b3a-b1e4-691b445d576c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f499d195-d048-4a09-a6e0-703de4be2224", "AQAAAAEAACcQAAAAEAoJGBhfHJqEIJf4yQmo0v6ReLgz0rYLbJFvmq57f3OWoeCL8hj91HpWeESfK/cF+w==", "21a5650c-be44-4f31-89fa-e194d5b1543e" });

            migrationBuilder.InsertData(
                table: "UsersFavourites",
                columns: new[] { "BandId", "UserId" },
                values: new object[,]
                {
                    { 1, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" },
                    { 2, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" },
                    { 3, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavourites_BandId",
                table: "UsersFavourites",
                column: "BandId");
        }
    }
}

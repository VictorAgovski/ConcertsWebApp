using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class SetNullableVenueIdInConcertsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "Concerts",
                type: "int",
                nullable: true,
                comment: "Venue unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Venue unique identifier - foreign key");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Concerts",
                type: "int",
                nullable: true,
                comment: "Band unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Band unique identifier - foreign key");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "Concerts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Venue unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Venue unique identifier - foreign key");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Concerts",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

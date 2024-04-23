using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class CascadeDeleteOnReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Band unique identifier - foreign key");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "955c756f-ebc7-412a-95f7-a601a7212814", "AQAAAAEAACcQAAAAEMIqBtgziIu/9oR/GGKN2Sjm+S7q0MkuqtFl5jykNycT/wBsJIsbZxZDTqnStoGUsw==", "a0b2f657-71ec-4b49-93f7-f669e5ed2a03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5be4ade2-b995-4bd0-87c0-f5cf79ba6db1", "AQAAAAEAACcQAAAAEBEoXwST2dYmSXmfNLzp/w8477Mhj0vVKd3LeH8+9hAnxWu1bOz9L9R2YHfdl0I7Sw==", "52a2a99c-23f0-498d-a62b-fd338e3fbb01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "065e7cf4-44d0-41e7-8bb4-5c712e97b65d", "AQAAAAEAACcQAAAAECjgF0+OUVLGGp/Ityt48dPN6aesqu6KvOqbizXqV2Ftz//WiM5Hpvd0jsN3QaG6sQ==", "b3f43112-c9a6-4d5c-ad39-140be2647298" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "BandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "BandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "BandId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts");

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "Reviews",
                type: "int",
                nullable: true,
                comment: "Band unique identifier - foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54ce0eef-78d8-4aef-9fff-bf5cb52ce2c5", "AQAAAAEAACcQAAAAEAGE+GXcDiFkYkayW8NMpr+aq/2KpFVOOijEnCxBouQJJp3VRYKAVioJDV8fpd+YCw==", "80f2d105-e74e-474c-94f7-1b1041622861" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e37fca1-4964-4cb1-a42c-fb69d0744afd", "AQAAAAEAACcQAAAAEHXLiRDp1fLs37SYZhYaveLCK/+3ncOKRhlMZVkyqeazcfpsj+zkSn6cJadhnw4Xaw==", "2917506c-4910-4a39-a58b-c43550f385a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "469b60df-c487-4b21-bfda-e0758b3f944b", "AQAAAAEAACcQAAAAEDNXGUp0mAiWOjx7VlXGR3b6HS/94o6VIjpraH9hwQWIqrutcIzQ1N7WUHy5Jgm9cA==", "f0abf717-010f-4920-afe2-1bc63f067d39" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "BandId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "BandId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "BandId",
                value: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Bands_BandId",
                table: "Concerts",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Venues_VenueId",
                table: "Concerts",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

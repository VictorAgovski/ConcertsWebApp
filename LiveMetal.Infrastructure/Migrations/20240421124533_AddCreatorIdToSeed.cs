using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class AddCreatorIdToSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 1,
                column: "CreatorId",
                value: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 2,
                column: "CreatorId",
                value: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1");

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 3,
                column: "CreatorId",
                value: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94f70680-6a4d-4d4f-8821-63aed00d3173", "AQAAAAEAACcQAAAAEHOYo25/1QlnKFExJJ/k83HfVtBn5KoALhtikud/i0KpXyTrTLMCcg/0Tp6y3n5/9w==", "fdd2f520-3e2b-44ff-90de-d6256d118302" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4238358c-2d69-46fe-a855-5c0cf954b685", "AQAAAAEAACcQAAAAEMxwNuuUYlZu04sE/gCJEozhd4hmQDSfCpprhYRB1/O/c+w9It42aUdTKiqAllcKug==", "1defe597-58c5-4cbb-b8d8-3dcbaa911357" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd41a9c8-6ec7-4ef0-9eb5-3c9f2fe69631", "AQAAAAEAACcQAAAAEB2n1MJaFUNeqEcoi0mwYHVKBviaJcXjlvmihFudQQOS/LDNaIBxFcbKMEsDQ2nYqw==", "5b00659e-34d0-4a58-b29b-f33bbc1540f5" });

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 1,
                column: "CreatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 2,
                column: "CreatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 3,
                column: "CreatorId",
                value: null);
        }
    }
}

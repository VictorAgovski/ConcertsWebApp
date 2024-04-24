using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class UpdateForeignKeyConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Concerts",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Concert creator unique identifier - foreign key");

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

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_CreatorId",
                table: "Concerts",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_AspNetUsers_CreatorId",
                table: "Concerts",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_AspNetUsers_CreatorId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_CreatorId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Concerts");

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
        }
    }
}

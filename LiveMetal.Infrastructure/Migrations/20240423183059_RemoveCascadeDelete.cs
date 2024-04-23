using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class RemoveCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

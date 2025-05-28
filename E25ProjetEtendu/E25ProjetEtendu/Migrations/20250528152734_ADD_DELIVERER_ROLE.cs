using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ADD_DELIVERER_ROLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "delivery-role-id", "42222222-2222-2222-2222-222222222222" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery-role-id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "deliverer-role-id", null, "Deliverer", "DELIVERER" },
                    { "deliverystation-role-id", null, "DeliveryStation", "DELIVERYSTATION" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f963d70d-2ecf-4b8d-a55a-ec73aed0a9a4", "AQAAAAIAAYagAAAAEHV77xWQPCWFdAaO1RhKTez6tIdt/fvXDYczJ9cgnsN+FVfYUyb9ZnU/MlKPeaWBAQ==", "f5c60c23-2b4b-4c6f-bae7-024c63141b0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5a4901e3-f455-4449-8c09-cc5485664898", "AQAAAAIAAYagAAAAEGo2JhZB0Zy4zZbJ/0wWjLAOUM1YjTCaHlt1hQBL0vFc9sCKLgJ9yOe1JH9CgInJpw==", "0b6926fa-5710-47f3-bf2e-1beeffbb1485", "jean@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a385f094-84f5-496b-94c4-4ec3a4dd80ba", "AQAAAAIAAYagAAAAEDHG8fGZ9yZCD+SdSEm+ZHKHEjmybeQhv+pPFgVQ0120eOMGGUmmVsM2m7sYRrZAww==", "2243f90c-e95a-4a7a-a777-fb9e7fb6614a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4443ad95-c7e4-4be5-8729-c2611afd3b6e", "AQAAAAIAAYagAAAAEGo2JhZB0Zy4zZbJ/0wWjLAOUM1YjTCaHlt1hQBL0vFc9sCKLgJ9yOe1JH9CgInJpw==", "9c481aab-fc32-4c88-85a6-1882d0c83f8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19015501-0a26-4cbd-83e9-8fc0fc248e09", "AQAAAAIAAYagAAAAEGo2JhZB0Zy4zZbJ/0wWjLAOUM1YjTCaHlt1hQBL0vFc9sCKLgJ9yOe1JH9CgInJpw==", "fcd2813c-d0ff-4841-9609-c5e481327714" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "941dd778-4dcb-48fb-9a77-9020d1765c45", "AQAAAAIAAYagAAAAEGo2JhZB0Zy4zZbJ/0wWjLAOUM1YjTCaHlt1hQBL0vFc9sCKLgJ9yOe1JH9CgInJpw==", "913113e6-a628-43db-9b37-a8e3a190bc67" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "deliverystation-role-id", "42222222-2222-2222-2222-222222222222" },
                    { "deliverer-role-id", "43333333-3333-3333-3333-333333333333" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "deliverystation-role-id", "42222222-2222-2222-2222-222222222222" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "deliverer-role-id", "43333333-3333-3333-3333-333333333333" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deliverer-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deliverystation-role-id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "delivery-role-id", null, "Delivery", "DELIVERY" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48d4fe69-9eba-4195-afde-46c7ce8fa62a", "AQAAAAIAAYagAAAAEKQ5DdH++nvyEgUUJd8mRcwwIRdHcYJNQ8hOhANZw3Ip/RqaJnqfjgTGIqbC+ACOtw==", "75b38016-ce8e-47ca-a566-139494105d29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "878ada56-d32c-4925-9143-fcca4a843a02", "AQAAAAIAAYagAAAAEJARQAdI9iigAXOsSJoUxjpwxCMQnnJA+uTOiX+aQJwL/5B9JSQPLQrPUVzzw68Ibg==", "fdb0652b-c6f9-43d1-8622-4445c4ed0a52", "user@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "106dae60-030c-4f41-9d00-c48c38c321c7", "AQAAAAIAAYagAAAAEKQnVR5lv17pKExf2LcafXYCI0weIGZPG1ylVzODFAvNHiR/8sL9XCKUYDSL7l6jeg==", "6c5b7717-f360-4784-8529-bc1c405918b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de80f09a-9233-444e-b27f-2b20fad30c0b", "AQAAAAIAAYagAAAAEJARQAdI9iigAXOsSJoUxjpwxCMQnnJA+uTOiX+aQJwL/5B9JSQPLQrPUVzzw68Ibg==", "4dce34d4-dac3-40ca-a3d3-ae9f94b75e45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "050492cf-fe9c-4996-b57d-10ee08ea7b04", "AQAAAAIAAYagAAAAEJARQAdI9iigAXOsSJoUxjpwxCMQnnJA+uTOiX+aQJwL/5B9JSQPLQrPUVzzw68Ibg==", "18552445-3f60-4986-9e04-3ea37db6c1cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd4b76b8-a89d-4b04-82e8-c21de378b363", "AQAAAAIAAYagAAAAEJARQAdI9iigAXOsSJoUxjpwxCMQnnJA+uTOiX+aQJwL/5B9JSQPLQrPUVzzw68Ibg==", "90f63bf2-dbf3-48d2-8d0f-3c48d28e042f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "delivery-role-id", "42222222-2222-2222-2222-222222222222" });
        }
    }
}

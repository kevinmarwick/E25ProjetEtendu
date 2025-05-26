using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ADD_USERS_SEED_DATA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "878ada56-d32c-4925-9143-fcca4a843a02", "AQAAAAIAAYagAAAAEJARQAdI9iigAXOsSJoUxjpwxCMQnnJA+uTOiX+aQJwL/5B9JSQPLQrPUVzzw68Ibg==", "fdb0652b-c6f9-43d1-8622-4445c4ed0a52" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "636774c9-e1b6-4a22-a92b-fcc476dda047", "AQAAAAIAAYagAAAAEBTXXTihDHwIYpDAurpMC+aHeWXubQ6iLlPv/dJhXj9YndUorT653YYu/uXIgHCbcw==", "46555518-b2a8-45a6-8ddc-9dacb67f9b65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93702ea9-7ecd-4150-be92-70fb02bb0b23", "AQAAAAIAAYagAAAAEF1/k05ekORzAsC9x29sZMKQNQ2VVQuqTMpOVR+hkSz0rWrbVFefYsYmU96FcnNSRQ==", "f866dfc1-8687-42d7-b442-401058df7feb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a36bc3b2-a12a-4809-a1ad-519f4708327c", "AQAAAAIAAYagAAAAEHsdQ1pPvKzQT0uXy3fiq6icqpoh0FStzRjuc8k1cpve1RG7leeahjPeo3UkxIGX2Q==", "eef6c348-b0c2-4ce2-9e96-4434f0b709fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "060cf558-f6a9-47ab-9a25-d4f5002c5552", "AQAAAAIAAYagAAAAEF1/k05ekORzAsC9x29sZMKQNQ2VVQuqTMpOVR+hkSz0rWrbVFefYsYmU96FcnNSRQ==", "8daf4f3d-456c-4a29-bdff-e9a4b993851b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85a2bdde-ee50-4165-ad5c-8f69e1d41f98", "AQAAAAIAAYagAAAAEF1/k05ekORzAsC9x29sZMKQNQ2VVQuqTMpOVR+hkSz0rWrbVFefYsYmU96FcnNSRQ==", "46392c2a-49f2-48be-829f-ca6a85b2eb5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ac0145a-00b4-4998-abd3-2be40d300824", "AQAAAAIAAYagAAAAEF1/k05ekORzAsC9x29sZMKQNQ2VVQuqTMpOVR+hkSz0rWrbVFefYsYmU96FcnNSRQ==", "a15acea6-872c-4640-843f-013648f4a9b5" });
        }
    }
}

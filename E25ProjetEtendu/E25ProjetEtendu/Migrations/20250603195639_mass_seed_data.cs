using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class mass_seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8542cc15-5252-409b-b855-31423bbbe150", "AQAAAAIAAYagAAAAEHiwvr0mxzv2HQTvRfuBdmv80P1c/bD75lx1DOw1DQ86IkjhPqTB8cXwbcIEiMBagg==", "60961d6f-6ac7-4074-a581-50e848b823cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae9b455c-fa46-45e1-b377-e1dc2f51a476", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "a0007a9a-ef25-4f23-8efe-fd007fd99c66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "675c3cc9-ae1d-4327-aac8-e7c5c616f38f", "AQAAAAIAAYagAAAAEGFsqWbciA9sqDsP0TsdrBBbTjtJ6W2DMWMFW3ElXmE0S75hCPv+BX44XoeNcjX/eA==", "aa684ca6-76b5-45b8-91dc-43586070a11d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a6a7270-c104-4c40-b701-5738a4589720", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "a1907c9f-b78f-4eb0-98a0-5e446f6eafa1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11cf34de-505f-4a3d-b547-62efc90abd3f", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "bbdd82cc-abcf-47d5-a375-aae46207d5fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74bc6bc8-bfd5-4e9b-af82-5a3c769cce59", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "4f7084cb-dd20-4ba9-bb52-09b059ec133f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "80000000-0000-0000-0000-000000000001", 0, 0m, "08306ddc-b56f-44d9-bbc5-34d34b4a28c9", "client1@test.com", true, "Client1", "Testeur", false, null, "CLIENT1@TEST.COM", "CLIENT1@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "f9b32cd1-9129-4195-b496-d09e83543e92", false, "client1@test.com" },
                    { "80000000-0000-0000-0000-000000000002", 0, 0m, "958510e7-650b-43c1-be35-5bb08456068d", "client2@test.com", true, "Client2", "Testeur", false, null, "CLIENT2@TEST.COM", "CLIENT2@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "bd099083-00ad-4910-9070-011eb95d8d7c", false, "client2@test.com" },
                    { "80000000-0000-0000-0000-000000000003", 0, 0m, "b4c7ce15-8019-42ed-b9c5-3becea68bb97", "client3@test.com", true, "Client3", "Testeur", false, null, "CLIENT3@TEST.COM", "CLIENT3@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "447c849c-33f1-452e-a584-a0ff7ce1ecb3", false, "client3@test.com" },
                    { "80000000-0000-0000-0000-000000000004", 0, 0m, "4166cdcc-7c95-4f7e-b00b-dd56696c26c5", "client4@test.com", true, "Client4", "Testeur", false, null, "CLIENT4@TEST.COM", "CLIENT4@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "652d8b22-8e14-416e-9b2c-5d715767b589", false, "client4@test.com" },
                    { "80000000-0000-0000-0000-000000000005", 0, 0m, "90bcb2fc-900b-44c0-b353-8e7d72f3fb17", "client5@test.com", true, "Client5", "Testeur", false, null, "CLIENT5@TEST.COM", "CLIENT5@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "dd331f03-92a7-4a2e-8cd5-26f6706c619c", false, "client5@test.com" },
                    { "80000000-0000-0000-0000-000000000006", 0, 0m, "c8ac2820-e0e2-4f05-a15a-2da8fbf51869", "client6@test.com", true, "Client6", "Testeur", false, null, "CLIENT6@TEST.COM", "CLIENT6@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "15ff324c-1f39-4b0e-a813-1f48490b718c", false, "client6@test.com" },
                    { "80000000-0000-0000-0000-000000000007", 0, 0m, "59370d64-6356-429f-8638-af7904ccd4c3", "client7@test.com", true, "Client7", "Testeur", false, null, "CLIENT7@TEST.COM", "CLIENT7@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "3e12e3d2-dc5d-436f-b36c-446cfcc20b88", false, "client7@test.com" },
                    { "80000000-0000-0000-0000-000000000008", 0, 0m, "c9ac5280-001d-4f2e-8cda-5f382a484e75", "client8@test.com", true, "Client8", "Testeur", false, null, "CLIENT8@TEST.COM", "CLIENT8@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "fa61166b-efb9-4c44-bb5b-04b0ea0c9ae9", false, "client8@test.com" },
                    { "80000000-0000-0000-0000-000000000009", 0, 0m, "e3106768-b160-4986-ad00-c273d4d0bbd2", "client9@test.com", true, "Client9", "Testeur", false, null, "CLIENT9@TEST.COM", "CLIENT9@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "09adc591-8ad1-40d2-9469-c22dbfb3a8ec", false, "client9@test.com" },
                    { "80000000-0000-0000-0000-000000000010", 0, 0m, "10aabe37-7b7a-4c76-ad63-d366d4127789", "client10@test.com", true, "Client10", "Testeur", false, null, "CLIENT10@TEST.COM", "CLIENT10@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "c96bb20f-b3dc-46e9-8c67-9cf4c675382f", false, "client10@test.com" },
                    { "80000000-0000-0000-0000-000000000011", 0, 0m, "bb3a9f52-c373-4936-b73a-2cd08cc789d9", "client11@test.com", true, "Client11", "Testeur", false, null, "CLIENT11@TEST.COM", "CLIENT11@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "acfbd05c-b6da-4f6f-9455-3eee29ddb9f4", false, "client11@test.com" },
                    { "80000000-0000-0000-0000-000000000012", 0, 0m, "34f3292e-7a71-4d32-862f-d770903e14d1", "client12@test.com", true, "Client12", "Testeur", false, null, "CLIENT12@TEST.COM", "CLIENT12@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "a2b8cef4-5f20-46b7-bc60-ca2c0c663993", false, "client12@test.com" },
                    { "80000000-0000-0000-0000-000000000013", 0, 0m, "70c98aad-efa7-4eb0-8a02-37fec628170c", "client13@test.com", true, "Client13", "Testeur", false, null, "CLIENT13@TEST.COM", "CLIENT13@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "8be00dbc-4def-4376-b7d3-3e09641e25ee", false, "client13@test.com" },
                    { "80000000-0000-0000-0000-000000000014", 0, 0m, "b59a1090-44f8-463e-9eab-b9c87c6aa754", "client14@test.com", true, "Client14", "Testeur", false, null, "CLIENT14@TEST.COM", "CLIENT14@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "b5682349-e1a8-46ed-a5ec-60c5567047c2", false, "client14@test.com" },
                    { "80000000-0000-0000-0000-000000000015", 0, 0m, "6fc6a0ab-a9be-405f-8c21-92391f0db418", "client15@test.com", true, "Client15", "Testeur", false, null, "CLIENT15@TEST.COM", "CLIENT15@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "61be3769-82fe-46d6-986d-8c5ae602c118", false, "client15@test.com" },
                    { "80000000-0000-0000-0000-000000000016", 0, 0m, "69414551-abdb-47ad-adf8-ba6d286dce4b", "client16@test.com", true, "Client16", "Testeur", false, null, "CLIENT16@TEST.COM", "CLIENT16@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "eab5c09f-d057-4acb-80a1-7e51dc9490a6", false, "client16@test.com" },
                    { "80000000-0000-0000-0000-000000000017", 0, 0m, "4399c86f-444c-46b5-bf30-61366cc5e83e", "client17@test.com", true, "Client17", "Testeur", false, null, "CLIENT17@TEST.COM", "CLIENT17@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "a1c0e3f7-dba9-4d3f-89ce-0628d997c200", false, "client17@test.com" },
                    { "80000000-0000-0000-0000-000000000018", 0, 0m, "82474076-4403-4665-9a9a-8829db2aed0f", "client18@test.com", true, "Client18", "Testeur", false, null, "CLIENT18@TEST.COM", "CLIENT18@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "e2318fb3-15bc-4bd1-a0b9-1cbf5c23182c", false, "client18@test.com" },
                    { "80000000-0000-0000-0000-000000000019", 0, 0m, "7209de67-3a06-4851-8c02-d8b60b30179d", "client19@test.com", true, "Client19", "Testeur", false, null, "CLIENT19@TEST.COM", "CLIENT19@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "126db0f4-05cc-4e84-8b7f-89dcbe1bca50", false, "client19@test.com" },
                    { "80000000-0000-0000-0000-000000000020", 0, 0m, "bb2a1a01-8244-4785-9a08-1c2cccbef55f", "client20@test.com", true, "Client20", "Testeur", false, null, "CLIENT20@TEST.COM", "CLIENT20@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "1225cb24-2d14-43a5-b352-2a6f0b50bfe4", false, "client20@test.com" },
                    { "80000000-0000-0000-0000-000000000021", 0, 0m, "950bcc6c-30a0-4beb-9a67-e0d7578cf8cd", "client21@test.com", true, "Client21", "Testeur", false, null, "CLIENT21@TEST.COM", "CLIENT21@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "4b203502-4cb8-48a2-a94d-84fc68b7684f", false, "client21@test.com" },
                    { "80000000-0000-0000-0000-000000000022", 0, 0m, "38da3cf1-5c2a-4c31-9a99-96bf140ecf72", "client22@test.com", true, "Client22", "Testeur", false, null, "CLIENT22@TEST.COM", "CLIENT22@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "6c1eea81-3ea2-400e-bef2-37f44bc59bf9", false, "client22@test.com" },
                    { "80000000-0000-0000-0000-000000000023", 0, 0m, "81f85848-c27d-4a7e-8ae7-09d38fbaacdb", "client23@test.com", true, "Client23", "Testeur", false, null, "CLIENT23@TEST.COM", "CLIENT23@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "66dd685e-0e31-4f47-aaa2-d401c589c5f2", false, "client23@test.com" },
                    { "80000000-0000-0000-0000-000000000024", 0, 0m, "d86e7687-c939-4555-a5b9-f2aee0954e9a", "client24@test.com", true, "Client24", "Testeur", false, null, "CLIENT24@TEST.COM", "CLIENT24@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "aa1839f8-8878-427b-b14d-cbf93eb07c6c", false, "client24@test.com" },
                    { "80000000-0000-0000-0000-000000000025", 0, 0m, "b1e36325-22d9-4f47-a099-4b2679a225a3", "client25@test.com", true, "Client25", "Testeur", false, null, "CLIENT25@TEST.COM", "CLIENT25@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "771f4746-7bd5-4a62-81a4-3f46f7a1e868", false, "client25@test.com" },
                    { "80000000-0000-0000-0000-000000000026", 0, 0m, "289ef140-a8a8-439c-b675-e10bca3263c3", "client26@test.com", true, "Client26", "Testeur", false, null, "CLIENT26@TEST.COM", "CLIENT26@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "1fe81073-5137-4b66-aecf-37f693c5f55a", false, "client26@test.com" },
                    { "80000000-0000-0000-0000-000000000027", 0, 0m, "abb6aa0f-2541-47ec-b062-bcdf6d687766", "client27@test.com", true, "Client27", "Testeur", false, null, "CLIENT27@TEST.COM", "CLIENT27@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "fa794c6f-c5bf-4620-a66a-e2961795e2fa", false, "client27@test.com" },
                    { "80000000-0000-0000-0000-000000000028", 0, 0m, "e07e4d44-cde7-4212-95af-545de37163b4", "client28@test.com", true, "Client28", "Testeur", false, null, "CLIENT28@TEST.COM", "CLIENT28@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "d4fe6411-7a44-46c2-b7b5-e24fecc9d42b", false, "client28@test.com" },
                    { "80000000-0000-0000-0000-000000000029", 0, 0m, "24b0cf17-77da-4b01-9dee-9a61c796df53", "client29@test.com", true, "Client29", "Testeur", false, null, "CLIENT29@TEST.COM", "CLIENT29@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "323ab830-d79d-4f5c-881b-cec9f89133fe", false, "client29@test.com" },
                    { "80000000-0000-0000-0000-000000000030", 0, 0m, "6968a7d7-8022-4d0f-b0f4-10f40bf093fb", "client30@test.com", true, "Client30", "Testeur", false, null, "CLIENT30@TEST.COM", "CLIENT30@TEST.COM", "AQAAAAIAAYagAAAAEKzxEcKyurfkGE95+K0vc+5gxsAzhTyZ3kXsCkIMW9U4pD3uAW+pmAldjXKjO1FlFw==", "5149465399", false, "1111b113-b8fc-4933-98b5-71bc1a847466", false, "client30@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "user-role-id", "80000000-0000-0000-0000-000000000001" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000002" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000003" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000004" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000005" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000006" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000007" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000008" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000009" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000010" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000011" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000012" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000013" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000014" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000015" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000016" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000017" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000018" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000019" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000020" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000021" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000022" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000023" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000024" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000025" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000026" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000027" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000028" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000029" },
                    { "user-role-id", "80000000-0000-0000-0000-000000000030" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "BuyerId", "CancellationActor", "CancellationDate", "CancellingUserId", "DelivererId", "Location", "OrderDate", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 3001, "80000000-0000-0000-0000-000000000001", null, null, null, null, "D-3001", new DateTime(2025, 6, 3, 15, 46, 37, 246, DateTimeKind.Local).AddTicks(500), 0, 3m },
                    { 3002, "80000000-0000-0000-0000-000000000002", null, null, null, null, "D-3002", new DateTime(2025, 6, 3, 15, 36, 37, 246, DateTimeKind.Local).AddTicks(667), 0, 3m },
                    { 3003, "80000000-0000-0000-0000-000000000003", null, null, null, null, "D-3003", new DateTime(2025, 6, 3, 15, 26, 37, 246, DateTimeKind.Local).AddTicks(676), 0, 3m },
                    { 3004, "80000000-0000-0000-0000-000000000004", null, null, null, null, "D-3004", new DateTime(2025, 6, 3, 15, 16, 37, 246, DateTimeKind.Local).AddTicks(681), 0, 3m },
                    { 3005, "80000000-0000-0000-0000-000000000005", null, null, null, null, "D-3005", new DateTime(2025, 6, 3, 15, 6, 37, 246, DateTimeKind.Local).AddTicks(687), 0, 3m },
                    { 3006, "80000000-0000-0000-0000-000000000006", null, null, null, null, "D-3006", new DateTime(2025, 6, 3, 14, 56, 37, 246, DateTimeKind.Local).AddTicks(766), 0, 3m },
                    { 3007, "80000000-0000-0000-0000-000000000007", null, null, null, null, "D-3007", new DateTime(2025, 6, 3, 14, 46, 37, 246, DateTimeKind.Local).AddTicks(780), 0, 3m },
                    { 3008, "80000000-0000-0000-0000-000000000008", null, null, null, null, "D-3008", new DateTime(2025, 6, 3, 14, 36, 37, 246, DateTimeKind.Local).AddTicks(785), 0, 3m },
                    { 3009, "80000000-0000-0000-0000-000000000009", null, null, null, null, "D-3009", new DateTime(2025, 6, 3, 14, 26, 37, 246, DateTimeKind.Local).AddTicks(790), 0, 3m },
                    { 3010, "80000000-0000-0000-0000-000000000010", null, null, null, null, "D-3010", new DateTime(2025, 6, 3, 14, 16, 37, 246, DateTimeKind.Local).AddTicks(798), 0, 3m },
                    { 3011, "80000000-0000-0000-0000-000000000011", null, null, null, null, "D-3011", new DateTime(2025, 6, 3, 14, 6, 37, 246, DateTimeKind.Local).AddTicks(820), 0, 3m },
                    { 3012, "80000000-0000-0000-0000-000000000012", null, null, null, null, "D-3012", new DateTime(2025, 6, 3, 13, 56, 37, 246, DateTimeKind.Local).AddTicks(825), 0, 3m },
                    { 3013, "80000000-0000-0000-0000-000000000013", null, null, null, null, "D-3013", new DateTime(2025, 6, 3, 13, 46, 37, 246, DateTimeKind.Local).AddTicks(830), 0, 3m },
                    { 3014, "80000000-0000-0000-0000-000000000014", null, null, null, null, "D-3014", new DateTime(2025, 6, 3, 13, 36, 37, 246, DateTimeKind.Local).AddTicks(835), 0, 3m },
                    { 3015, "80000000-0000-0000-0000-000000000015", null, null, null, null, "D-3015", new DateTime(2025, 6, 3, 13, 26, 37, 246, DateTimeKind.Local).AddTicks(840), 0, 3m },
                    { 3016, "80000000-0000-0000-0000-000000000001", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3016", new DateTime(2025, 5, 24, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(891), 2, 5m },
                    { 3017, "80000000-0000-0000-0000-000000000002", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3017", new DateTime(2025, 5, 23, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(906), 2, 5m },
                    { 3018, "80000000-0000-0000-0000-000000000003", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3018", new DateTime(2025, 5, 22, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(915), 2, 5m },
                    { 3019, "80000000-0000-0000-0000-000000000004", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3019", new DateTime(2025, 5, 21, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(920), 2, 5m },
                    { 3020, "80000000-0000-0000-0000-000000000005", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3020", new DateTime(2025, 5, 20, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(926), 2, 5m },
                    { 3021, "80000000-0000-0000-0000-000000000006", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3021", new DateTime(2025, 5, 19, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(972), 2, 5m },
                    { 3022, "80000000-0000-0000-0000-000000000007", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3022", new DateTime(2025, 5, 18, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(978), 2, 5m },
                    { 3023, "80000000-0000-0000-0000-000000000008", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3023", new DateTime(2025, 5, 17, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(983), 2, 5m },
                    { 3024, "80000000-0000-0000-0000-000000000009", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3024", new DateTime(2025, 5, 16, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(988), 2, 5m },
                    { 3025, "80000000-0000-0000-0000-000000000010", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3025", new DateTime(2025, 5, 15, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(993), 2, 5m },
                    { 3026, "80000000-0000-0000-0000-000000000011", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3026", new DateTime(2025, 5, 14, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1066), 2, 5m },
                    { 3027, "80000000-0000-0000-0000-000000000012", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3027", new DateTime(2025, 5, 13, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1072), 2, 5m },
                    { 3028, "80000000-0000-0000-0000-000000000013", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3028", new DateTime(2025, 5, 12, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1077), 2, 5m },
                    { 3029, "80000000-0000-0000-0000-000000000014", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3029", new DateTime(2025, 5, 11, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1082), 2, 5m },
                    { 3030, "80000000-0000-0000-0000-000000000015", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3030", new DateTime(2025, 5, 10, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1097), 2, 5m },
                    { 3031, "80000000-0000-0000-0000-000000000016", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3031", new DateTime(2025, 5, 9, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1167), 2, 5m },
                    { 3032, "80000000-0000-0000-0000-000000000017", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3032", new DateTime(2025, 5, 8, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1174), 2, 5m },
                    { 3033, "80000000-0000-0000-0000-000000000018", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3033", new DateTime(2025, 5, 7, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1178), 2, 5m },
                    { 3034, "80000000-0000-0000-0000-000000000019", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3034", new DateTime(2025, 5, 6, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1188), 2, 5m },
                    { 3035, "80000000-0000-0000-0000-000000000020", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3035", new DateTime(2025, 5, 5, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1193), 2, 5m },
                    { 3036, "80000000-0000-0000-0000-000000000021", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3036", new DateTime(2025, 5, 4, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1198), 2, 5m },
                    { 3037, "80000000-0000-0000-0000-000000000022", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3037", new DateTime(2025, 5, 3, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1202), 2, 5m },
                    { 3038, "80000000-0000-0000-0000-000000000023", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3038", new DateTime(2025, 5, 2, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1207), 2, 5m },
                    { 3039, "80000000-0000-0000-0000-000000000024", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3039", new DateTime(2025, 5, 1, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1212), 2, 5m },
                    { 3040, "80000000-0000-0000-0000-000000000025", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3040", new DateTime(2025, 4, 30, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1216), 2, 5m },
                    { 3041, "80000000-0000-0000-0000-000000000026", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3041", new DateTime(2025, 4, 29, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1221), 2, 5m },
                    { 3042, "80000000-0000-0000-0000-000000000027", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3042", new DateTime(2025, 4, 28, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1226), 2, 5m },
                    { 3043, "80000000-0000-0000-0000-000000000028", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3043", new DateTime(2025, 4, 27, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1230), 2, 5m },
                    { 3044, "80000000-0000-0000-0000-000000000029", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3044", new DateTime(2025, 4, 26, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1235), 2, 5m },
                    { 3045, "80000000-0000-0000-0000-000000000030", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3045", new DateTime(2025, 4, 25, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1288), 2, 5m },
                    { 3046, "80000000-0000-0000-0000-000000000001", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3046", new DateTime(2025, 4, 24, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1300), 2, 5m },
                    { 3047, "80000000-0000-0000-0000-000000000002", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3047", new DateTime(2025, 4, 23, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1305), 2, 5m },
                    { 3048, "80000000-0000-0000-0000-000000000003", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3048", new DateTime(2025, 4, 22, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1310), 2, 5m },
                    { 3049, "80000000-0000-0000-0000-000000000004", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3049", new DateTime(2025, 4, 21, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1315), 2, 5m },
                    { 3050, "80000000-0000-0000-0000-000000000005", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3050", new DateTime(2025, 4, 20, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1321), 2, 5m },
                    { 3051, "80000000-0000-0000-0000-000000000006", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3051", new DateTime(2025, 4, 19, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1326), 2, 5m },
                    { 3052, "80000000-0000-0000-0000-000000000007", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3052", new DateTime(2025, 4, 18, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1331), 2, 5m },
                    { 3053, "80000000-0000-0000-0000-000000000008", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3053", new DateTime(2025, 4, 17, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1335), 2, 5m },
                    { 3054, "80000000-0000-0000-0000-000000000009", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3054", new DateTime(2025, 4, 16, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1340), 2, 5m },
                    { 3055, "80000000-0000-0000-0000-000000000010", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3055", new DateTime(2025, 4, 15, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1345), 2, 5m },
                    { 3056, "80000000-0000-0000-0000-000000000011", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3056", new DateTime(2025, 4, 14, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1350), 2, 5m },
                    { 3057, "80000000-0000-0000-0000-000000000012", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3057", new DateTime(2025, 4, 13, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1355), 2, 5m },
                    { 3058, "80000000-0000-0000-0000-000000000013", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3058", new DateTime(2025, 4, 12, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1360), 2, 5m },
                    { 3059, "80000000-0000-0000-0000-000000000014", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3059", new DateTime(2025, 4, 11, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1364), 2, 5m },
                    { 3060, "80000000-0000-0000-0000-000000000015", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3060", new DateTime(2025, 4, 10, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1369), 2, 5m },
                    { 3061, "80000000-0000-0000-0000-000000000016", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3061", new DateTime(2025, 4, 9, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1374), 2, 5m },
                    { 3062, "80000000-0000-0000-0000-000000000017", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3062", new DateTime(2025, 4, 8, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1379), 2, 5m },
                    { 3063, "80000000-0000-0000-0000-000000000018", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3063", new DateTime(2025, 4, 7, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1384), 2, 5m },
                    { 3064, "80000000-0000-0000-0000-000000000019", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3064", new DateTime(2025, 4, 6, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1389), 2, 5m },
                    { 3065, "80000000-0000-0000-0000-000000000020", null, null, null, "43333333-3333-3333-3333-333333333333", "C-3065", new DateTime(2025, 4, 5, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1393), 2, 5m },
                    { 3066, "80000000-0000-0000-0000-000000000001", 1, new DateTime(2025, 2, 24, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1503), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3066", new DateTime(2025, 2, 23, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1491), 3, 2m },
                    { 3067, "80000000-0000-0000-0000-000000000002", 1, new DateTime(2025, 2, 23, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1521), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3067", new DateTime(2025, 2, 22, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1518), 3, 2m },
                    { 3068, "80000000-0000-0000-0000-000000000003", 1, new DateTime(2025, 2, 22, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1529), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3068", new DateTime(2025, 2, 21, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1525), 3, 2m },
                    { 3069, "80000000-0000-0000-0000-000000000004", 1, new DateTime(2025, 2, 21, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1538), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3069", new DateTime(2025, 2, 20, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1534), 3, 2m },
                    { 3070, "80000000-0000-0000-0000-000000000005", 1, new DateTime(2025, 2, 20, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1545), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3070", new DateTime(2025, 2, 19, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1541), 3, 2m },
                    { 3071, "80000000-0000-0000-0000-000000000006", 1, new DateTime(2025, 2, 19, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1552), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3071", new DateTime(2025, 2, 18, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1548), 3, 2m },
                    { 3072, "80000000-0000-0000-0000-000000000007", 1, new DateTime(2025, 2, 18, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1559), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3072", new DateTime(2025, 2, 17, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1556), 3, 2m },
                    { 3073, "80000000-0000-0000-0000-000000000008", 1, new DateTime(2025, 2, 17, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1566), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3073", new DateTime(2025, 2, 16, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1563), 3, 2m },
                    { 3074, "80000000-0000-0000-0000-000000000009", 1, new DateTime(2025, 2, 16, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1573), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3074", new DateTime(2025, 2, 15, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1570), 3, 2m },
                    { 3075, "80000000-0000-0000-0000-000000000010", 1, new DateTime(2025, 2, 15, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1580), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3075", new DateTime(2025, 2, 14, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1577), 3, 2m },
                    { 3076, "80000000-0000-0000-0000-000000000011", 1, new DateTime(2025, 2, 14, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1588), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3076", new DateTime(2025, 2, 13, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1584), 3, 2m },
                    { 3077, "80000000-0000-0000-0000-000000000012", 1, new DateTime(2025, 2, 13, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1595), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3077", new DateTime(2025, 2, 12, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1592), 3, 2m },
                    { 3078, "80000000-0000-0000-0000-000000000013", 1, new DateTime(2025, 2, 12, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1602), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3078", new DateTime(2025, 2, 11, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1599), 3, 2m },
                    { 3079, "80000000-0000-0000-0000-000000000014", 1, new DateTime(2025, 2, 11, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1609), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3079", new DateTime(2025, 2, 10, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1606), 3, 2m },
                    { 3080, "80000000-0000-0000-0000-000000000015", 1, new DateTime(2025, 2, 10, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1616), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3080", new DateTime(2025, 2, 9, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1613), 3, 2m },
                    { 3081, "80000000-0000-0000-0000-000000000016", 1, new DateTime(2025, 2, 9, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1624), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3081", new DateTime(2025, 2, 8, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1620), 3, 2m },
                    { 3082, "80000000-0000-0000-0000-000000000017", 1, new DateTime(2025, 2, 8, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1715), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3082", new DateTime(2025, 2, 7, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1711), 3, 2m },
                    { 3083, "80000000-0000-0000-0000-000000000018", 1, new DateTime(2025, 2, 7, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1723), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3083", new DateTime(2025, 2, 6, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1720), 3, 2m },
                    { 3084, "80000000-0000-0000-0000-000000000019", 1, new DateTime(2025, 2, 6, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1731), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3084", new DateTime(2025, 2, 5, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1727), 3, 2m },
                    { 3085, "80000000-0000-0000-0000-000000000020", 1, new DateTime(2025, 2, 5, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1738), "42222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "X-3085", new DateTime(2025, 2, 4, 15, 56, 37, 246, DateTimeKind.Local).AddTicks(1734), 3, 2m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1001, 3001, 1, 1, 3m },
                    { 1002, 3002, 1, 1, 3m },
                    { 1003, 3003, 1, 1, 3m },
                    { 1004, 3004, 1, 1, 3m },
                    { 1005, 3005, 1, 1, 3m },
                    { 1006, 3006, 1, 1, 3m },
                    { 1007, 3007, 1, 1, 3m },
                    { 1008, 3008, 1, 1, 3m },
                    { 1009, 3009, 1, 1, 3m },
                    { 1010, 3010, 1, 1, 3m },
                    { 1011, 3011, 1, 1, 3m },
                    { 1012, 3012, 1, 1, 3m },
                    { 1013, 3013, 1, 1, 3m },
                    { 1014, 3014, 1, 1, 3m },
                    { 1015, 3015, 1, 1, 3m },
                    { 1016, 3016, 2, 1, 5m },
                    { 1017, 3017, 2, 1, 5m },
                    { 1018, 3018, 2, 1, 5m },
                    { 1019, 3019, 2, 1, 5m },
                    { 1020, 3020, 2, 1, 5m },
                    { 1021, 3021, 2, 1, 5m },
                    { 1022, 3022, 2, 1, 5m },
                    { 1023, 3023, 2, 1, 5m },
                    { 1024, 3024, 2, 1, 5m },
                    { 1025, 3025, 2, 1, 5m },
                    { 1026, 3026, 2, 1, 5m },
                    { 1027, 3027, 2, 1, 5m },
                    { 1028, 3028, 2, 1, 5m },
                    { 1029, 3029, 2, 1, 5m },
                    { 1030, 3030, 2, 1, 5m },
                    { 1031, 3031, 2, 1, 5m },
                    { 1032, 3032, 2, 1, 5m },
                    { 1033, 3033, 2, 1, 5m },
                    { 1034, 3034, 2, 1, 5m },
                    { 1035, 3035, 2, 1, 5m },
                    { 1036, 3036, 2, 1, 5m },
                    { 1037, 3037, 2, 1, 5m },
                    { 1038, 3038, 2, 1, 5m },
                    { 1039, 3039, 2, 1, 5m },
                    { 1040, 3040, 2, 1, 5m },
                    { 1041, 3041, 2, 1, 5m },
                    { 1042, 3042, 2, 1, 5m },
                    { 1043, 3043, 2, 1, 5m },
                    { 1044, 3044, 2, 1, 5m },
                    { 1045, 3045, 2, 1, 5m },
                    { 1046, 3046, 2, 1, 5m },
                    { 1047, 3047, 2, 1, 5m },
                    { 1048, 3048, 2, 1, 5m },
                    { 1049, 3049, 2, 1, 5m },
                    { 1050, 3050, 2, 1, 5m },
                    { 1051, 3051, 2, 1, 5m },
                    { 1052, 3052, 2, 1, 5m },
                    { 1053, 3053, 2, 1, 5m },
                    { 1054, 3054, 2, 1, 5m },
                    { 1055, 3055, 2, 1, 5m },
                    { 1056, 3056, 2, 1, 5m },
                    { 1057, 3057, 2, 1, 5m },
                    { 1058, 3058, 2, 1, 5m },
                    { 1059, 3059, 2, 1, 5m },
                    { 1060, 3060, 2, 1, 5m },
                    { 1061, 3061, 2, 1, 5m },
                    { 1062, 3062, 2, 1, 5m },
                    { 1063, 3063, 2, 1, 5m },
                    { 1064, 3064, 2, 1, 5m },
                    { 1065, 3065, 2, 1, 5m },
                    { 1066, 3066, 3, 1, 2m },
                    { 1067, 3067, 3, 1, 2m },
                    { 1068, 3068, 3, 1, 2m },
                    { 1069, 3069, 3, 1, 2m },
                    { 1070, 3070, 3, 1, 2m },
                    { 1071, 3071, 3, 1, 2m },
                    { 1072, 3072, 3, 1, 2m },
                    { 1073, 3073, 3, 1, 2m },
                    { 1074, 3074, 3, 1, 2m },
                    { 1075, 3075, 3, 1, 2m },
                    { 1076, 3076, 3, 1, 2m },
                    { 1077, 3077, 3, 1, 2m },
                    { 1078, 3078, 3, 1, 2m },
                    { 1079, 3079, 3, 1, 2m },
                    { 1080, 3080, 3, 1, 2m },
                    { 1081, 3081, 3, 1, 2m },
                    { 1082, 3082, 3, 1, 2m },
                    { 1083, 3083, 3, 1, 2m },
                    { 1084, 3084, 3, 1, 2m },
                    { 1085, 3085, 3, 1, 2m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000002" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000003" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000004" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000005" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000006" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000007" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000008" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000009" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000010" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000011" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000012" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000013" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000014" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000015" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000016" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000017" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000018" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000019" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000020" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000021" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000022" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000023" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000024" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000025" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000026" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000027" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000028" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000029" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "80000000-0000-0000-0000-000000000030" });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1048);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1049);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1058);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1059);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1069);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1071);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1072);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1073);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1074);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1075);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1076);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1077);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1078);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1079);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1084);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1085);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3001);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3004);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3005);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3006);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3007);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3008);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3009);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3010);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3011);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3012);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3013);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3014);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3015);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3016);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3017);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3018);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3019);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3020);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3021);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3022);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3023);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3024);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3025);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3026);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3027);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3028);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3029);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3030);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3031);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3032);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3033);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3034);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3035);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3036);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3037);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3038);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3039);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3040);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3041);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3042);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3043);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3044);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3045);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3046);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3047);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3048);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3049);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3050);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3051);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3052);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3053);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3054);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3055);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3056);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3057);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3058);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3059);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3060);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3061);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3062);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3063);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3064);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3065);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3066);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3067);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3068);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3069);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3070);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3071);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3072);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3073);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3074);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3075);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3076);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3077);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3078);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3079);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3080);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3081);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3082);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3083);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3084);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3085);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000006");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000007");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000008");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000009");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000010");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000011");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000012");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000013");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000014");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000015");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000016");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000017");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000018");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000019");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000020");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000021");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000022");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000023");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000024");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000025");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000026");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000027");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000028");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000029");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80000000-0000-0000-0000-000000000030");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c7003f2-e816-473a-bf93-2b7df3fe175d", "AQAAAAIAAYagAAAAEDQW32Li/+QK/sYpUVyryJ0eOAay4enCyb6jRqUPxxNLSROvIpXo71TirdayNedlew==", "bb38db1d-1d66-4328-8518-3491740c4635" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0ee7214-59fd-4d3a-b6f5-80f06f7a765c", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "e0e40b9d-1dd9-48e6-a12f-60c98f165edd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9883216e-2d54-4ad2-a444-c0c5babbd9cb", "AQAAAAIAAYagAAAAEIBfmkCa1sHY44t2hBZ8p2vNlpbbfhY5uPqElUemoJc+QpUd01l4SYfutlaT96o6IQ==", "5a28aa8c-8638-4f7b-951e-203ad0e56e60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a536ecd-b4cb-4e1d-8ca8-58ac4f763018", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "31fe873d-0ddc-44ab-9a43-4b483ed8f2f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcaecddb-6417-426c-b16a-2a218fb468af", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "b038333a-8bf1-4f2f-8656-106d655420be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29cd8cd-2461-4559-b063-ddaa55cbcf2d", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "ca257ddd-172f-42ff-ada8-33758be592e8" });
        }
    }
}

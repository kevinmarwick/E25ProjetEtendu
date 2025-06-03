using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class update_users_info : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "livreur-role-id", "43333333-3333-3333-3333-333333333333" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "livreur-role-id");

            migrationBuilder.AddColumn<int>(
                name: "CancellationActor",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancellingUserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "deliverer-role-id", null, "Deliverer", "DELIVERER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "a9f54411-0e2b-4d98-94d2-b00509da10ac", "edouardlivraisonsante@gmail.com", "EDOUARDLIVRAISONSANTE@GMAIL.COM", "EDOUARDLIVRAISONSANTE@GMAIL.COM", "AQAAAAIAAYagAAAAEOjT6mZM0cAgfjDNnqxt5ieHYSdVSCgzcBvQuH5sBiTmx7FQa/fhE8S1DiQ6Ld9THA==", "5149465399", "3937098c-ef2d-4fbe-ae55-5b39c61ee584", "edouardlivraisonsante@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "a39a73fe-9b4e-4737-bf43-9bf690506bd4", "jeanbeliveau011@gmail.com", "Beliveau", "JEANBELIVEAU011@GMAIL.COM", "JEANBELIVEAU011@GMAIL.COM", "AQAAAAIAAYagAAAAECVEqf9uIZ9S9MstlSh8xs4cM6EbO5WnpzCKK7Fu5uNlBiivlTwQEfFeUC0IZjRLQw==", "5149465399", "613a08f7-b237-4c46-9931-394a52eabedd", "jeanbeliveau011@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "ba408c4b-6306-46e2-8457-019e703e53cd", "postelivraisonedouard@gmail.com", "Poste", "POSTELIVRAISONEDOUARD@GMAIL.COM", "POSTELIVRAISONEDOUARD@GMAIL.COM", "AQAAAAIAAYagAAAAELU4UNRh5ednpu8dMdIoeUIw1sgpJyyihm9VH8E2JfCit+GDjvh09S7RQvPQd9OUHg==", "5149465399", "1fb07227-d511-48a1-a394-30957a713678", "postelivraisonedouard@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "0f0377d9-eadd-4f3b-a368-b097b840b569", "jacobby911@gmail.com", "Lelivreux", "JACOBBY911@GMAIL.COM", "JACOBBY911@GMAIL.COM", "AQAAAAIAAYagAAAAECVEqf9uIZ9S9MstlSh8xs4cM6EbO5WnpzCKK7Fu5uNlBiivlTwQEfFeUC0IZjRLQw==", "5149465399", "10d7c3df-209e-4a1b-b9f4-3ab35544d9c0", "jacobby911@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "305419e6-54df-47ef-94e9-e8eaa397577c", "maximee011@gmail.com", "Ninep", "MAXIMEE011@GMAIL.COM", "MAXIMEE011@GMAIL.COM", "AQAAAAIAAYagAAAAECVEqf9uIZ9S9MstlSh8xs4cM6EbO5WnpzCKK7Fu5uNlBiivlTwQEfFeUC0IZjRLQw==", "5149465399", "2369c7de-7991-4237-b154-df1cec118a40", "maximee011@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "1a706456-d626-43da-b4ab-1851c884327e", "nicolasquebec420@gmail.com", "Quebec", "NICOLASQUEBEC420@GMAIL.COM", "NICOLASQUEBEC420@GMAIL.COM", "AQAAAAIAAYagAAAAECVEqf9uIZ9S9MstlSh8xs4cM6EbO5WnpzCKK7Fu5uNlBiivlTwQEfFeUC0IZjRLQw==", "5149465399", "b9697b8c-51ce-4e34-a4e9-f180d6d19df4", "nicolasquebec420@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2001,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2002,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2003,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2004,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2005,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2006,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2007,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2008,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2009,
                columns: new[] { "CancellationActor", "CancellationDate", "CancellingUserId" },
                values: new object[] { null, null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "deliverer-role-id", "43333333-3333-3333-3333-333333333333" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "deliverer-role-id", "43333333-3333-3333-3333-333333333333" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deliverer-role-id");

            migrationBuilder.DropColumn(
                name: "CancellationActor",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CancellationDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CancellingUserId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "livreur-role-id", null, "Livreur", "LIVREUR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "c10d0088-c7f3-4fd6-b3c7-f7f709cffcf2", "admin@example.com", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOIdkYxq+1XB2VFMqMyyKjudbkBCSULAdVkf/e6DHGrYieFD0EOd9uk43zHId35VrQ==", null, "9b108876-a962-4c77-bef2-87a3fd5818d9", "admin@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "5b8d1b86-c210-4b12-a64b-36c16104c9f4", "user@example.com", "Utilisateur", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, "c6f61dda-d64f-4ebb-81b1-6da97ed91aa6", "jean@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "457d3ca4-4781-47c0-bcdf-fd847f752b71", "livreur@example.com", "Livreur", "LIVREUR@EXAMPLE.COM", "LIVREUR@EXAMPLE.COM", "AQAAAAIAAYagAAAAEL6eT59Yc/Lxqo4O6f/6vsDsIt8TU38t+KFFxcJtIHXrZHwzJCYaRGE9+AxIeWP/VA==", null, "c0b072a8-b781-4fcc-8fd8-054a4b53a820", "livreur@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "cbb0cd42-3660-4437-add6-56da75eb6e5e", "jacob@example.com", "Utilisateur", "JACOB@EXAMPLE.COM", "JACOB@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, "9b01a83f-fed9-4d6d-9982-aefb6fbdeb56", "jacob@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "fdf9479c-da23-4c2a-856c-e248226f693f", "maxime@example.com", "Utilisateur", "MAXIME@EXAMPLE.COM", "MAXIME@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, "49c5985e-050f-4298-8043-3f33738dda96", "maxime@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "2720d98e-83cd-453c-bf05-df164328856a", "nicolas@example.com", "Utilisateur", "NICOLAS@EXAMPLE.COM", "NICOLAS@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, "d327e4ca-be80-433e-b44b-564fb13d7c31", "nicolas@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "livreur-role-id", "43333333-3333-3333-3333-333333333333" });
        }
    }
}

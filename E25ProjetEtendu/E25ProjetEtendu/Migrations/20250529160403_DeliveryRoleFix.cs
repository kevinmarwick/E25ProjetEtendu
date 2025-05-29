using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryRoleFix : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "deliverer-role-id", null, "Deliverer", "DELIVERER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "384aea33-7c53-408a-b26c-79df024388bf", "AQAAAAIAAYagAAAAEF2fxFXdkev51MzgUyFz4wk+sHiObSX4e0DYIJtalj2899yFzPZDb6eyhP9tbNw7mA==", "d20c9e4a-0d81-4168-8c69-dc5c6af9f6e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af5d043b-9fc2-4fd7-9aac-1973f1008e0b", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", "6097c829-94bd-4dbc-b934-cea057decfa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e8a207d-a598-444f-bab4-51b295efcd99", "AQAAAAIAAYagAAAAECdZWWhRIZZ27yESWqXUfVTWxN3PuV41yOmO5vADog/yQM0b3j6CAxUhbVk0NaHLRg==", "7b3972b1-f03a-41b1-b473-be6b287777a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4a1237-6ec5-4ef6-9e0e-600482366dd9", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", "abaade34-17d9-420b-8f78-6e597c13051d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55a64862-bc9b-4b66-886f-30d4e19d7d6c", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", "6fc394a8-0b81-489f-8887-15ed13ba1942" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4243228d-293b-41bb-b535-9ece457d4c8b", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", "59b60a68-38b7-41d1-b52f-59edabbc1e71" });

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "livreur-role-id", null, "Livreur", "LIVREUR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c10d0088-c7f3-4fd6-b3c7-f7f709cffcf2", "AQAAAAIAAYagAAAAEOIdkYxq+1XB2VFMqMyyKjudbkBCSULAdVkf/e6DHGrYieFD0EOd9uk43zHId35VrQ==", "9b108876-a962-4c77-bef2-87a3fd5818d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b8d1b86-c210-4b12-a64b-36c16104c9f4", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", "c6f61dda-d64f-4ebb-81b1-6da97ed91aa6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "457d3ca4-4781-47c0-bcdf-fd847f752b71", "AQAAAAIAAYagAAAAEL6eT59Yc/Lxqo4O6f/6vsDsIt8TU38t+KFFxcJtIHXrZHwzJCYaRGE9+AxIeWP/VA==", "c0b072a8-b781-4fcc-8fd8-054a4b53a820" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbb0cd42-3660-4437-add6-56da75eb6e5e", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", "9b01a83f-fed9-4d6d-9982-aefb6fbdeb56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdf9479c-da23-4c2a-856c-e248226f693f", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", "49c5985e-050f-4298-8043-3f33738dda96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2720d98e-83cd-453c-bf05-df164328856a", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", "d327e4ca-be80-433e-b44b-564fb13d7c31" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "livreur-role-id", "43333333-3333-3333-3333-333333333333" });
        }
    }
}

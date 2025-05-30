using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class MIG_RESET2 : Migration
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38146c09-78ef-462d-9d4a-7d46a4b0120b", "AQAAAAIAAYagAAAAEDaj1GYDmT0AkFE/juuMQCdvUXgUPhKCVSOjykbEzAICFFlYCNZtcDkpNQh7AeieFQ==", "78cb89af-a012-447f-8a0c-1395ad1e9684" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72bbc71d-5f75-4a91-b5ed-2067c4f6e692", "AQAAAAIAAYagAAAAEIhYsR0U4MwiHGgjuAg9spVmDYro80iCpPeO5XxtA2Qj3kuKjq8jJ7ilgmd3rVM1bQ==", "fdd5dd3c-44ad-4b9d-a953-307bf8701b4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9310a091-3634-4080-8d5e-611a16e8da08", "AQAAAAIAAYagAAAAELFuIic87PexQCvLH1oviIG7+/Yi1Cg+/9khzF3Fw26rMu76oFLubcWRIO0lkbOAsw==", "5ebf7afe-618d-419b-bcb3-fcf8237d6df9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daef4464-865d-4d9e-b9d9-1e8dec33c343", "AQAAAAIAAYagAAAAEIhYsR0U4MwiHGgjuAg9spVmDYro80iCpPeO5XxtA2Qj3kuKjq8jJ7ilgmd3rVM1bQ==", "3d154fb3-405a-4b61-bbf6-0643b69eed94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "174582eb-64e9-4d58-98aa-e29e0c4d63a1", "AQAAAAIAAYagAAAAEIhYsR0U4MwiHGgjuAg9spVmDYro80iCpPeO5XxtA2Qj3kuKjq8jJ7ilgmd3rVM1bQ==", "ae5f4100-c9ff-41ba-8fa3-2946e0a24850" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd0d8e07-00f4-443a-914a-cb0cce73c9d5", "AQAAAAIAAYagAAAAEIhYsR0U4MwiHGgjuAg9spVmDYro80iCpPeO5XxtA2Qj3kuKjq8jJ7ilgmd3rVM1bQ==", "09b5be32-30bd-4a37-9129-caecf0c8c8cc" });

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

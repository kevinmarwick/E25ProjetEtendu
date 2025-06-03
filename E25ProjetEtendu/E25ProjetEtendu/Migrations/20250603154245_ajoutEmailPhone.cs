using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajoutEmailPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "50e02674-5bcd-45d5-8077-f19b90ff3c6e", "edouardlivraisonsante@gmail.com", "EDOUARDLIVRAISONSANTE@GMAIL.COM", "EDOUARDLIVRAISONSANTE@GMAIL.COM", "AQAAAAIAAYagAAAAEJPMMSrYVsoPqMyfyOxSvcryWnbKmkhOJMPFfgfj9OTb0SX0icLcm9D7yKBQWzob3w==", "5149465399", "58e870c7-e786-48d4-a711-07d45ac9eb44", "edouardlivraisonsante@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "78a41163-f38e-4757-9469-2418da9c95bd", "jeanbeliveau011@gmail.com", "Beliveau", "JEANBELIVEAU011@GMAIL.COM", "JEANBELIVEAU011@GMAIL.COM", "AQAAAAIAAYagAAAAEHa0BpjhTFYuipNTdKI8agbMxqvbthm95Bv+S0Tc9H75eMVezel2W6qpFMXffiMHRg==", "5149465399", "a360213e-22e9-48c3-9399-67034c6bf330", "jeanbeliveau011@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "2295bcdc-f4df-4ea1-87eb-632e7cc63a7e", "postelivraisonedouard@gmail.com", "Poste", "POSTELIVRAISONEDOUARD@GMAIL.COM", "POSTELIVRAISONEDOUARD@GMAIL.COM", "AQAAAAIAAYagAAAAEGVK6dfx62i8d6scn5AcYlaT2AVMcowZVkmG0WCidZDBQf+i1nofJXNZb8ULYN2sKA==", "5149465399", "12ed36c8-7494-46af-91d0-c80aef11b1f4", "postelivraisonedouard@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "504c0e80-e8a6-4dd5-93f1-5ef1818ef5fa", "jacobby911@gmail.com", "Lelivreux", "JACOBBY911@GMAIL.COM", "JACOBBY911@GMAIL.COM", "AQAAAAIAAYagAAAAEHa0BpjhTFYuipNTdKI8agbMxqvbthm95Bv+S0Tc9H75eMVezel2W6qpFMXffiMHRg==", "5149465399", "735690a2-1ab5-4182-9464-04998155554e", "jacobby911@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "5e36a988-dbba-456a-9483-e1b3e2a06ad7", "maximee011@gmail.com", "Ninep", "MAXIMEE011@GMAIL.COM", "MAXIMEE011@GMAIL.COM", "AQAAAAIAAYagAAAAEHa0BpjhTFYuipNTdKI8agbMxqvbthm95Bv+S0Tc9H75eMVezel2W6qpFMXffiMHRg==", "5149465399", "f421b53d-5edd-4eaf-8526-d6013e6602bc", "maximee011@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "6c004337-33e5-4e2b-bae6-087fc8e420b2", "nicolasquebec420@gmail.com", "Quebec", "NICOLASQUEBEC420@GMAIL.COM", "NICOLASQUEBEC420@GMAIL.COM", "AQAAAAIAAYagAAAAEHa0BpjhTFYuipNTdKI8agbMxqvbthm95Bv+S0Tc9H75eMVezel2W6qpFMXffiMHRg==", "5149465399", "bfb3e894-9738-4487-9326-5a84477e147e", "nicolasquebec420@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "384aea33-7c53-408a-b26c-79df024388bf", "admin@example.com", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF2fxFXdkev51MzgUyFz4wk+sHiObSX4e0DYIJtalj2899yFzPZDb6eyhP9tbNw7mA==", null, "d20c9e4a-0d81-4168-8c69-dc5c6af9f6e0", "admin@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "af5d043b-9fc2-4fd7-9aac-1973f1008e0b", "user@example.com", "Utilisateur", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", null, "6097c829-94bd-4dbc-b934-cea057decfa2", "jean@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "1e8a207d-a598-444f-bab4-51b295efcd99", "livreur@example.com", "Livreur", "LIVREUR@EXAMPLE.COM", "LIVREUR@EXAMPLE.COM", "AQAAAAIAAYagAAAAECdZWWhRIZZ27yESWqXUfVTWxN3PuV41yOmO5vADog/yQM0b3j6CAxUhbVk0NaHLRg==", null, "7b3972b1-f03a-41b1-b473-be6b287777a3", "livreur@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "3d4a1237-6ec5-4ef6-9e0e-600482366dd9", "jacob@example.com", "Utilisateur", "JACOB@EXAMPLE.COM", "JACOB@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", null, "abaade34-17d9-420b-8f78-6e597c13051d", "jacob@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "55a64862-bc9b-4b66-886f-30d4e19d7d6c", "maxime@example.com", "Utilisateur", "MAXIME@EXAMPLE.COM", "MAXIME@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", null, "6fc394a8-0b81-489f-8887-15ed13ba1942", "maxime@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "4243228d-293b-41bb-b535-9ece457d4c8b", "nicolas@example.com", "Utilisateur", "NICOLAS@EXAMPLE.COM", "NICOLAS@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHq19s+xWeFkOL5fLtHwqI+bnhvWxUSy88YJ5PuVhE0cCohu+ooask2vTZncMFQaeQ==", null, "59b60a68-38b7-41d1-b52f-59edabbc1e71", "nicolas@example.com" });
        }
    }
}

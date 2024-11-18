using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class TablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Contact identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Contact first name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Contact last name"),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Email of the contact person"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Mobile phone number"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Address for correspondation"),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Website for more information")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                },
                comment: "The main entry of the contact table");

            migrationBuilder.CreateTable(
                name: "ApplicationUsersContacts",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "ApplicationUser identifier"),
                    ContactId = table.Column<int>(type: "int", nullable: false, comment: "Contact identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersContacts", x => new { x.ApplicationUserId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many-to-many relation table");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber", "Website" },
                values: new object[] { 1, "Gotham City", "imbatman@batman.com", "Bruce", "Wayne", "+359881223344", "www.batman.com" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber", "Website" },
                values: new object[] { 2, "Sofia City", "persho_g@gmail.com", "Pesho", "Georgiev", "+359883123456", "peterandco-ltd.com" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber", "Website" },
                values: new object[] { 3, "Plovdiv City", "dimipetrov@mail.bg", "Dimitrichko", "Petrov", "+359899123456", "dimi98.bg" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersContacts_ContactId",
                table: "ApplicationUsersContacts",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersContacts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bonneTable.Admin.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    HashedPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "Id", "HashedPassword", "Salt", "Username" },
                values: new object[] { new Guid("f06899ea-eae4-45fe-8930-6a0cb983673f"), "O8OAc+g+w7l/V0aNCdEnYx+3zE3AXqcJMTCB0ylLhhY=", "eKM5gUWEhws0jPdCxdjrJw==", "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");
        }
    }
}

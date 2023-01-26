using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Services.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "email", "password", "phone" },
                values: new object[] { 1, "hassan", "hassan@gmail.com", "1234", "0633445566" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "email", "password", "phone" },
                values: new object[] { 2, "hamid", "hamid@gmail.com", "1234", "0633445566" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "email", "password", "phone" },
                values: new object[] { 3, "SAID", "SAID@gmail.com", "1234", "0633445566" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

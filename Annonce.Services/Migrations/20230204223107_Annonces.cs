using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annonce.Services.Migrations
{
    public partial class Annonces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annonces",
                columns: table => new
                {
                    AnnonceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Premuim = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonces", x => x.AnnonceId);
                });

            migrationBuilder.InsertData(
                table: "Annonces",
                columns: new[] { "AnnonceId", "Desc", "Image", "Premuim", "Price", "UserId", "title" },
                values: new object[,]
                {
                    { 1, "telephone economique", new byte[0], false, 233.0, 1, "nokia vintage" },
                    { 2, "pc gamer neuf spec nvidia rtx ram 32g stockage 1tb", new byte[0], false, 12000.0, 1, "pc gamer neuf" },
                    { 3, "trotinette electrique xiaomi 30h charge", new byte[0], false, 3500.0, 1, "trotinnete electrique xiaomi" },
                    { 4, "Golf8 importe de bern", new byte[0], true, 335000.0, 1, "Golf8 importe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonces");
        }
    }
}

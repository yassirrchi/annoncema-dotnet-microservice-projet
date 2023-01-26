using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annonce.Services.Migrations
{
    public partial class Annonce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annonces",
                columns: table => new
                {
                    AnnonceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnonceName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
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
                columns: new[] { "AnnonceId", "AnnonceName", "Desc", "Image", "Premuim", "Price", "UserId" },
                values: new object[] { 1, "trotinette", "nice", null, false, 15.0, 1 });

            migrationBuilder.InsertData(
                table: "Annonces",
                columns: new[] { "AnnonceId", "AnnonceName", "Desc", "Image", "Premuim", "Price", "UserId" },
                values: new object[] { 2, "sendala", "nice", null, false, 30.0, 2 });

            migrationBuilder.InsertData(
                table: "Annonces",
                columns: new[] { "AnnonceId", "AnnonceName", "Desc", "Image", "Premuim", "Price", "UserId" },
                values: new object[] { 3, "Audi A3", "nice", null, true, 250000.0, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonces");
        }
    }
}

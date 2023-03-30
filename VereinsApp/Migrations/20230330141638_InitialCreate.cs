using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VereinsApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mitglieder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geburtsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plz = table.Column<int>(type: "int", nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beitrittsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mitgliedschaftskategorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bezahlmethode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notiz = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitglieder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rechnungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezahldatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Betrag = table.Column<double>(type: "float", nullable: false),
                    MitgliedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rechnungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rechnungen_Mitglieder_MitgliedId",
                        column: x => x.MitgliedId,
                        principalTable: "Mitglieder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rechnungen_MitgliedId",
                table: "Rechnungen",
                column: "MitgliedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rechnungen");

            migrationBuilder.DropTable(
                name: "Mitglieder");
        }
    }
}

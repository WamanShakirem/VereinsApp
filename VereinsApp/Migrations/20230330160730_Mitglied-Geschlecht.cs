using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VereinsApp.Migrations
{
    /// <inheritdoc />
    public partial class MitgliedGeschlecht : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Geschlecht",
                table: "Mitglieder",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geschlecht",
                table: "Mitglieder");
        }
    }
}

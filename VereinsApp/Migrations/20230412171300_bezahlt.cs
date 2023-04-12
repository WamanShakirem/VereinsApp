using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VereinsApp.Migrations
{
    /// <inheritdoc />
    public partial class bezahlt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Bezahlt",
                table: "Mitglieder",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bezahlt",
                table: "Mitglieder");
        }
    }
}

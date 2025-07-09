using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartwayFinal.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEquipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgentesId",
                table: "Equipos",
                newName: "MemberId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Equipos",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Equipos");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Equipos",
                newName: "AgentesId");
        }
    }
}

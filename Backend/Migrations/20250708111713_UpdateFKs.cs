using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartwayFinal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EquipoId",
                table: "Agentes",
                newName: "OwnerEquiposId");

            migrationBuilder.AddColumn<string>(
                name: "MemberEquiposId",
                table: "Agentes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberEquiposId",
                table: "Agentes");

            migrationBuilder.RenameColumn(
                name: "OwnerEquiposId",
                table: "Agentes",
                newName: "EquipoId");
        }
    }
}

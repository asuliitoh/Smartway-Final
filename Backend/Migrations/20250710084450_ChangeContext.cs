using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartwayFinal.Migrations
{
    /// <inheritdoc />
    public partial class ChangeContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiembrosEquipo_Agentes_MiembrosId",
                table: "MiembrosEquipo");

            migrationBuilder.DropForeignKey(
                name: "FK_MiembrosEquipo_Equipos_MiembroEquiposId",
                table: "MiembrosEquipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MiembrosEquipo",
                table: "MiembrosEquipo");

            migrationBuilder.RenameTable(
                name: "MiembrosEquipo",
                newName: "AgenteEquipo");

            migrationBuilder.RenameIndex(
                name: "IX_MiembrosEquipo_MiembrosId",
                table: "AgenteEquipo",
                newName: "IX_AgenteEquipo_MiembrosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgenteEquipo",
                table: "AgenteEquipo",
                columns: new[] { "MiembroEquiposId", "MiembrosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AgenteEquipo_Agentes_MiembrosId",
                table: "AgenteEquipo",
                column: "MiembrosId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AgenteEquipo_Equipos_MiembroEquiposId",
                table: "AgenteEquipo",
                column: "MiembroEquiposId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgenteEquipo_Agentes_MiembrosId",
                table: "AgenteEquipo");

            migrationBuilder.DropForeignKey(
                name: "FK_AgenteEquipo_Equipos_MiembroEquiposId",
                table: "AgenteEquipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgenteEquipo",
                table: "AgenteEquipo");

            migrationBuilder.RenameTable(
                name: "AgenteEquipo",
                newName: "MiembrosEquipo");

            migrationBuilder.RenameIndex(
                name: "IX_AgenteEquipo_MiembrosId",
                table: "MiembrosEquipo",
                newName: "IX_MiembrosEquipo_MiembrosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MiembrosEquipo",
                table: "MiembrosEquipo",
                columns: new[] { "MiembroEquiposId", "MiembrosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MiembrosEquipo_Agentes_MiembrosId",
                table: "MiembrosEquipo",
                column: "MiembrosId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MiembrosEquipo_Equipos_MiembroEquiposId",
                table: "MiembrosEquipo",
                column: "MiembroEquiposId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

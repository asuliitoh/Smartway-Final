using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartwayFinal.Migrations
{
    /// <inheritdoc />
    public partial class ChangeContext4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiembrosEquipo");

            migrationBuilder.CreateTable(
                name: "AgenteEquipos",
                columns: table => new
                {
                    AgenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenteEquipos", x => new { x.AgenteId, x.EquipoId });
                    table.ForeignKey(
                        name: "FK_AgenteEquipos_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgenteEquipos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgenteEquipos_EquipoId",
                table: "AgenteEquipos",
                column: "EquipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgenteEquipos");

            migrationBuilder.CreateTable(
                name: "MiembrosEquipo",
                columns: table => new
                {
                    MiembroEquiposId = table.Column<int>(type: "INTEGER", nullable: false),
                    MiembrosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiembrosEquipo", x => new { x.MiembroEquiposId, x.MiembrosId });
                    table.ForeignKey(
                        name: "FK_MiembrosEquipo_Agentes_MiembrosId",
                        column: x => x.MiembrosId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiembrosEquipo_Equipos_MiembroEquiposId",
                        column: x => x.MiembroEquiposId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiembrosEquipo_MiembrosId",
                table: "MiembrosEquipo",
                column: "MiembrosId");
        }
    }
}

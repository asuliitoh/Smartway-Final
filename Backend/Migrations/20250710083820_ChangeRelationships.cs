using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartwayFinal.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "OperacionesId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "MemberEquiposId",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "OwnerEquiposId",
                table: "Agentes");

            migrationBuilder.AddColumn<int>(
                name: "CreadorId",
                table: "Operaciones",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Operaciones",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Equipos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
                name: "IX_Operaciones_EquipoId",
                table: "Operaciones",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_OwnerId",
                table: "Equipos",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MiembrosEquipo_MiembrosId",
                table: "MiembrosEquipo",
                column: "MiembrosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Agentes_OwnerId",
                table: "Equipos",
                column: "OwnerId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Equipos_EquipoId",
                table: "Operaciones",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Agentes_OwnerId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Equipos_EquipoId",
                table: "Operaciones");

            migrationBuilder.DropTable(
                name: "MiembrosEquipo");

            migrationBuilder.DropIndex(
                name: "IX_Operaciones_EquipoId",
                table: "Operaciones");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_OwnerId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Operaciones");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Operaciones");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Equipos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Equipos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperacionesId",
                table: "Equipos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberEquiposId",
                table: "Agentes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerEquiposId",
                table: "Agentes",
                type: "TEXT",
                nullable: true);
        }
    }
}

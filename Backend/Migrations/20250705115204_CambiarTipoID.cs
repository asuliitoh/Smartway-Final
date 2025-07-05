using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartwayFinal.Migrations
{
    /// <inheritdoc />
    public partial class CambiarTipoID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Equipos_EquipoId",
                table: "Agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Equipos_EquipoId",
                table: "Operaciones");

            migrationBuilder.DropIndex(
                name: "IX_Operaciones_EquipoId",
                table: "Operaciones");

            migrationBuilder.DropIndex(
                name: "IX_Agentes_EquipoId",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Operaciones");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Operaciones",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Equipos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "AgentesId",
                table: "Equipos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperacionesId",
                table: "Equipos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EquipoId",
                table: "Agentes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Agentes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentesId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "OperacionesId",
                table: "Equipos");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Operaciones",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<long>(
                name: "EquipoId",
                table: "Operaciones",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Equipos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "EquipoId",
                table: "Agentes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Agentes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_EquipoId",
                table: "Operaciones",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_EquipoId",
                table: "Agentes",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Equipos_EquipoId",
                table: "Agentes",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Equipos_EquipoId",
                table: "Operaciones",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");
        }
    }
}

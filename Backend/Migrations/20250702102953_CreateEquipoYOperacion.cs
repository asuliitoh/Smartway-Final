using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartwayFinal.Migrations
{
    /// <inheritdoc />
    public partial class CreateEquipoYOperacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Agentes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "EquipoId",
                table: "Agentes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rango",
                table: "Agentes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Especialidad = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EquipoId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operaciones_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_EquipoId",
                table: "Agentes",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_EquipoId",
                table: "Operaciones",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Equipos_EquipoId",
                table: "Agentes",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Equipos_EquipoId",
                table: "Agentes");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Agentes_EquipoId",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "Rango",
                table: "Agentes");

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });
        }
    }
}

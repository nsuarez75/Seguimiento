using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguimiento.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    IncidenciaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", nullable: true),
                    HoraInicio = table.Column<string>(type: "TEXT", nullable: true),
                    HoraFin = table.Column<string>(type: "TEXT", nullable: true),
                    Instalacion = table.Column<string>(type: "TEXT", nullable: true),
                    Proyecto = table.Column<string>(type: "TEXT", nullable: true),
                    Produccion = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.IncidenciaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidencias");
        }
    }
}

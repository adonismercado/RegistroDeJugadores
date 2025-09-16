using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeJugadores.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPartidasToVictorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Partidas",
                table: "Jugadores",
                newName: "Victorias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Victorias",
                table: "Jugadores",
                newName: "Partidas");
        }
    }
}

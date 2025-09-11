using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeJugadores.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEstadoTablero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoTablero",
                table: "Partidas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoTablero",
                table: "Partidas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }
    }
}

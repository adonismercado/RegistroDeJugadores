using System.ComponentModel.DataAnnotations;

namespace RegistroDeJugadores.Models;

    public class Jugadores
{
    [Key]
    public int JugadorId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = null!;

    public int Partidas { get; set; } = 0;
}


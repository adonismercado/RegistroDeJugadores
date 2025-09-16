using System.ComponentModel.DataAnnotations;

namespace RegistroDeJugadores.Models;

public class Jugadores
{
    [Key]
    public int JugadorId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = null!;
    
    public int Victorias { get; set; } = 0;
    public int Derrotas { get; set; } = 0;
    public int Empates { get; set; } = 0;
}
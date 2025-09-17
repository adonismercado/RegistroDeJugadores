using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [InverseProperty(nameof(Models.Movimientos.Jugador))]
    public virtual ICollection<Movimientos> Movimientos { get; set; } = new List<Movimientos>();
}
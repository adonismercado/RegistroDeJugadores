using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDeJugadores.Models;

public class Partidas
{
    [Key]
    public int PartidaId { get; set; }
    [Required(ErrorMessage = "Debes seleccionar 1 jugador")]
    public int Jugador1Id { get; set; }
    public int? Jugador2Id { get; set; }

    [Required(ErrorMessage = "El EstadoPartida es obligatorio.")]
    [StringLength(20)]
    public string EstadoPartida { get; set; } = string.Empty;

    public int? GanadorId { get; set; }
    [Required(ErrorMessage = "TurnoJugadorID es obligatorio")]
    public int TurnoJugadorId { get; set; }

    [StringLength(9)]
    public string EstadoTablero { get; set; }

    public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
    public DateTime? FechaFin { get; set; }

    // Propiedades de navegación
    [ForeignKey(nameof(Jugador1Id))]
    public virtual Jugadores Jugador1 { get; set; }

    [ForeignKey(nameof(Jugador2Id))]
    public virtual Jugadores Jugador2 { get; set; }

    [ForeignKey(nameof(GanadorId))]
    public virtual Jugadores Ganador { get; set; }

    [ForeignKey(nameof(TurnoJugadorId))]
    public virtual Jugadores TurnoJugador { get; set; }
}


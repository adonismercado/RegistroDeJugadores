using System.ComponentModel.DataAnnotations;

namespace RegistroDeJugadores.Models
{
    public class Jugadores
    {
        [Key]
        public string JugadorId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public int Partidas { get; set; }
    }
}

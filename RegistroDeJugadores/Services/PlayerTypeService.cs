using RegistroDeJugadores.Models;

namespace RegistroDeJugadores.Services
{
    public class PlayerTypeService
    {
        public bool gameStarted { get; set; }
        public PlayerType? playerTypeSelection { get; set; }
        public PlayerType? _currentPlayerType { get; set; } = PlayerType.X;
        public PlayerType? winner { get; set; }
        public bool esEmpate { get; set; }
        public PlayerType?[] board { get; set; } = new PlayerType?[9];

        public int? Jugador1Id { get; set; }
        public int? Jugador2Id { get; set; }

        public void Reset()
        {
            gameStarted = false;
            playerTypeSelection = null;
            _currentPlayerType = PlayerType.X;
            winner = null;
            esEmpate = false;
            board = new PlayerType?[9];
        }
    }
}

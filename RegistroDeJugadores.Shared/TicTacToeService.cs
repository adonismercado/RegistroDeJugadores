namespace RegistroDeJugadores.Shared;
public class TicTacToeService
{
    public enum PlayerType { X, O }

    public bool GameStarted { get; set; }
    public PlayerType? PlayerTypeSelection { get; set; }
    public PlayerType CurrentPlayerType { get; set; } = PlayerType.X;
    public PlayerType? Winner { get; set; }
    public bool EsEmpate { get; set; }
    public PlayerType?[] Board { get; set; } = new PlayerType?[9];

    public int Jugador1Id { get; set; }
    public int? Jugador2Id { get; set; }
    public int PartidaId { get; set; }
    public int MiJugadorId { get; set; }

    public string? ErrorMessage { get; set; }

    public string MiSimbolo => MiJugadorId == Jugador1Id ? "X" : "O";

    public void ResetGame()
    {
        GameStarted = false;
        PartidaId = 0;
        Jugador1Id = 0;
        Jugador2Id = 0;
        MiJugadorId = 0;
        PlayerTypeSelection = null;
        Board = new PlayerType?[9];
        ErrorMessage = null;
        Winner = null;
        EsEmpate = false;
        CurrentPlayerType = PlayerType.X;
    }
}
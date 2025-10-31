namespace RegistroDeJugadores.Dtos;

public record PartidasRequest(
    int Jugador1Id,
    int? Jugador2Id);

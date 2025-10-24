namespace RegistroJugadores.Shared.Dtos;

public record PartidasResponse(
    int PartidaId,
    int Jugador1Id,
    int? Jugador2Id);

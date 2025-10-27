using System.Security.Cryptography.X509Certificates;

namespace RegistroDeJugadores.Shared.Dtos;

public record PartidaResponse(
    int PartidaId,
    int Jugador1Id,
    int? Jugador2Id);

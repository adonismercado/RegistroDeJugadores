using System.Security.Cryptography.X509Certificates;

namespace RegistroDeJugadores.Shared.Dtos;

public record PartidaResponse(
    int Partidaid,
    int Jugador1Id,
    int? Jugador2Id);

using System.Security.Cryptography.X509Certificates;

namespace RegistroJugadores.Shared.Dtos;

public record MovimientosResponse(
    int PartidaId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna);

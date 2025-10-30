namespace RegistroDeJugadores.Dtos;
public record MovimientosResponse(
    int MovimientoId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna
);

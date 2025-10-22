﻿namespace RegistroDeJugadores.Shared.Dtos;

public record MovimientosResponse(
    int PartidaId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna
);

﻿namespace RegistroDeJugadores.Shared.Dtos;

public record MovimientoResponse(
    int PartidaId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna);

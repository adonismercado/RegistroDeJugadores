﻿namespace RegistroJugadores.Shared.Dtos;

public record MovimientosRequest(
    int PartidaId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna);

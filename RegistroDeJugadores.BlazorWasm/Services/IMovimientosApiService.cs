using RegistroDeJugadores.Shared;
using RegistroDeJugadores.Shared.Dtos;

namespace RegistroDeJugadores.BlazorWasm.Services;

public interface IMovimientosApiService
{
    Task<Resource<MovimientosResponse>> GetPartidasAsync(int partidaId);
    Task<Resource<MovimientosResponse>> PostMovimientos(int partidaId, string jugador, int posicionFila, int posicionColumna);
}

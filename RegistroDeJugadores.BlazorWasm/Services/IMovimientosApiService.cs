using RegistroDeJugadores.Shared;
using RegistroDeJugadores.Shared.Dtos;

namespace RegistroDeJugadores.BlazorWasm.Services;

public interface IMovimientosApiService
{
    Task<Resource<MovimientosResponse>> GetMovimientosAsync(int partidaId);
    Task<Resource<bool>> PostMovimientos(int partidaId, string jugador, int posicionFila, int posicionColumna);
}

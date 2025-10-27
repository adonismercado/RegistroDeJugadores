using RegistroDeJugadores.Shared;
using RegistroDeJugadores.Shared.Dtos;

namespace RegistroDeJugadores.BlazorWasm.Services;

public interface IMovimientosApiService
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientos(int partidaId);
    Task<Resource<MovimientoResponse>> PostMovimientos(int partidaId, string jugador, int posicionFila, int posicionColumna);
}

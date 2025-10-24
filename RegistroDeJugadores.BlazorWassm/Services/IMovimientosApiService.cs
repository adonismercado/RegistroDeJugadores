using RegistroJugadores.Shared;
using RegistroJugadores.Shared.Dtos;
namespace RegistroDeJugadores.BlazorWassm.Services;

public interface IMovimientosApiService
{
    Task<Resource<List<MovimientosResponse>>> GetMovimientosAsnyc(int partidaId);
    Task<Resource<MovimientosResponse>> PostMovimiento(int partidaId, string jugador, int posicionFila, int posicionColumna);
}

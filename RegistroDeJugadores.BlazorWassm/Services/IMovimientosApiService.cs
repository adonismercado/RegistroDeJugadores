using RegistroJugadores.Shared;
using RegistroJugadores.Shared.Dtos;
namespace RegistroDeJugadores.BlazorWassm.Services;

public interface IMovimientosApiService
{
    Task<Resource<MovimientosResponse[]>> GetMovimientosAsnyc(int partidaId);
    Task<Resource<bool>> PostMovimientos(int partidaId, string jugador, int posicionFila, int posicionColumna);
}

using RegistroDeJugadores.Dtos;

namespace RegistroDeJugadores.Services
{
    public interface IMovimientosApiService
    {
        Task<Resource<List<MovimientosResponse>>> GetMovimientosByPartidaAsync(int partidaId);
        Task<Resource<MovimientosResponse>> PostMovimiento(int partidaId, string jugador, int posicionFila, int posicionColumna);
    }
}

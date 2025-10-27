using RegistroDeJugadores.Shared;
using RegistroDeJugadores.Shared.Dtos;

namespace RegistroDeJugadores.BlazorWasm.Services
{
    public interface IPartidasApiService
    {
        Task<Resource<List<PartidaResponse>>> GetPartidas();
        Task<Resource<PartidaResponse>> GetPartida(int partidaId);
        Task<Resource<PartidaResponse>> PostPartida(int jugador1Id, int? jugador2Id);
        Task<Resource<PartidaResponse>> PutPartida(int partidaId, int jugador1Id, int? jugador2Id);
    }
}

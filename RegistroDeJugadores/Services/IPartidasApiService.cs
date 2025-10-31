using RegistroDeJugadores.Dtos;

namespace RegistroDeJugadores.Services;

public interface IPartidasApiService
{
    Task<Resource<PartidasResponse>> GetPartidaAsync(int partidaId);
    Task<Resource<PartidasResponse>> PostPartida(int jugador1Id, int? jugador2Id);
    Task<Resource<PartidasResponse>> PutPartida(int partidaId, int jugador1Id, int? jugador2Id);
}

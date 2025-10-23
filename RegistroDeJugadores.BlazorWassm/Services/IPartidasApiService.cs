using RegistroJugadores.Shared;
using RegistroJugadores.Shared.Dtos;

namespace RegistroDeJugadores.BlazorWassm.Services;

public interface IPartidasApiService
{
    Task<Resource<List<PartidasResponse>>> GetPartidasAsync();
    Task<Resource<PartidasResponse>> GetPartidaAsync(int partidaId);
    Task<Resource<PartidasResponse>> PostPartida(int jugador1, int jugador2);
}

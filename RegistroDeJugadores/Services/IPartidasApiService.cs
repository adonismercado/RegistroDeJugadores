using RegistroDeJugadores.Dtos;

namespace RegistroDeJugadores.Services;

public interface IPartidasApiService
{
    Task<Resource<PartidasResponse>> GetPartidaAsync(int partidaId);
}

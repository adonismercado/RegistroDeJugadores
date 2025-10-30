using RegistroDeJugadores.Dtos;

namespace RegistroDeJugadores.Services;

public interface IPartidasApiService
{
    Task<Resource<PartidasResponse>> GetPartidaAsync(int partidaId);
}

public class PartidasApiService(HttpClient httpClient) : IPartidasApiService
{
    public async Task<Resource<PartidasResponse>> GetPartidaAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<PartidasResponse>($"api/Partidas/{partidaId}");
            return new Resource<PartidasResponse>.Success(response!);
        }
        catch (Exception ex)
        {
            return new Resource<PartidasResponse>.Error(ex.Message);
        }
    }
}

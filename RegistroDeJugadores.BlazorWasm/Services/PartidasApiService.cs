using RegistroDeJugadores.Shared;
using RegistroDeJugadores.Shared.Dtos;
using System.Net.Http.Json;
using System.Net.WebSockets;

namespace RegistroDeJugadores.BlazorWasm.Services;

public class PartidasApiService(HttpClient httpClient) : IPartidasApiService
{
    public async Task<Resource<List<PartidaResponse>>> GetPartidas()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<PartidaResponse>>("api/Partidas");
            return new Resource<List<PartidaResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<PartidaResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<PartidaResponse>> GetPartida(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<PartidaResponse>($"api/Partidas/{partidaId}");
            return new Resource<PartidaResponse>.Success(response!);
        }
        catch (Exception ex)
        {
            return new Resource<PartidaResponse>.Error(ex.Message);
        }
    }

    public async Task<Resource<PartidaResponse>> PostPartida(int jugador1Id, int? jugador2Id)
    {
        var request = new PartidaRequest(jugador1Id, jugador2Id);

        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Partidas", request);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<PartidaResponse>();
            return new Resource<PartidaResponse>.Success(created!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<PartidaResponse>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<PartidaResponse>.Error("Respuesta inválida del servidor.");
        }
    }

    public async Task<Resource<PartidaResponse>> PutPartida(int partidaId, int jugador1Id, int? jugador2Id)
    {
        var request = new PartidaRequest(jugador1Id, jugador2Id);

        try
        {
            var response = await httpClient.PutAsJsonAsync($"api/Partidas/{partidaId}", request);
            response.EnsureSuccessStatusCode();
            return new Resource<PartidaResponse>.Success(null!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<PartidaResponse>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<PartidaResponse>.Error("Respuesta inválida del servidor.");
        }
    }
}

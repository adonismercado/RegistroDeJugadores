using RegistroDeJugadores.Shared;
using RegistroDeJugadores.Shared.Dtos;
using System.Net.Http;
using System.Net.Http.Json;

namespace RegistroDeJugadores.BlazorWasm.Services;

public class MovimientosApiService(HttpClient httpClient) : IMovimientosApiService
{
    public async Task<Resource<MovimientosResponse>> GetMovimientosAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<MovimientosResponse>($"api/Movimientos/{partidaId}");
            return new Resource<MovimientosResponse>.Success(response!);
        }
        catch (Exception ex)
        {
            return new Resource<MovimientosResponse>.Error(ex.Message);
        }
    }

    public async Task<Resource<bool>> PostMovimientos(int partidaId, string jugador, int fila, int columna)
    {
        var request = new MovimientosRequest(partidaId, jugador, fila, columna);

        try
        {
            var response = await httpClient.PostAsJsonAsync($"api/Movimientos", request);
            response.EnsureSuccessStatusCode();
            return new Resource<bool>.Success(true);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<bool>.Error($"Error de red: {ex.Message}");
        }
    }
}

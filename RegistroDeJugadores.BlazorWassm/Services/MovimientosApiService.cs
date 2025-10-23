using RegistroJugadores.Shared;
using RegistroJugadores.Shared.Dtos;
using System.Net.Http.Json;

namespace RegistroDeJugadores.BlazorWassm.Services;

public class MovimientosApiService (HttpClient httpClient)
{
    public async Task<Resource<MovimientosResponse[]>> GetMovimientosAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<MovimientosResponse[]>($"api/Movimientos/{partidaId}");
            return new Resource<MovimientosResponse[]>.Success(response!);
        }
        catch (Exception ex)
        {
            return new Resource<MovimientosResponse[]>.Error(ex.Message);
        }
    }

    public async Task<Resource<bool>> PostMovimientos(int partidaId, string jugador, int posicionFila, int posicionColumna)
    {
        var request = new MovimientosRequest(partidaId, jugador, posicionFila, posicionColumna);
        
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Movimientos", request);
            response.EnsureSuccessStatusCode();
            return new Resource<bool>.Success(true);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<bool>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<bool>.Error("Respuesta invalida del servidor.");
        }
    }
}

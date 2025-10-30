using RegistroDeJugadores.Dtos;

namespace RegistroDeJugadores.Services;

public class MovimientosApiService(HttpClient httpClient) : IMovimientosApiService
{
    public async Task<Resource<List<MovimientosResponse>>> GetMovimientosByPartidaAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<MovimientosResponse>>($"api/Movimientos/{partidaId}");
            return new Resource<List<MovimientosResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<MovimientosResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<MovimientosResponse>> PostMovimiento(int partidaId, string jugador, int posicionFila, int posicionColumna)
    {
        var request = new MovimientosRequest(partidaId, jugador, posicionFila, posicionColumna);
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Movimientos", request);
            response.EnsureSuccessStatusCode();
            return new Resource<MovimientosResponse>.Success(null!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<MovimientosResponse>.Error($"Error en la red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<MovimientosResponse>.Error("Respuesta no valida del servidor");
        }
    }
}

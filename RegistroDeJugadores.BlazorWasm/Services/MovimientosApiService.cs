﻿using RegistroDeJugadores.Shared;
using RegistroDeJugadores.Shared.Dtos;
using System.Net.Http.Json;

namespace RegistroDeJugadores.BlazorWasm.Services
{
    public class MovimientosApiService(HttpClient httpClient) : IMovimientosApiService
    {
        public async Task<Resource<List<MovimientoResponse>>> GetMovimientos(int partidaId)
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<MovimientoResponse>>($"api/Movimientos/{partidaId}");
                return new Resource<List<MovimientoResponse>>.Success(response ?? []);
            }
            catch (Exception ex)
            {
                return new Resource<List<MovimientoResponse>>.Error(ex.Message);
            }
        }

        public async Task<Resource<MovimientoResponse>> PostMovimientos(int partidaId, string jugador, int posicionFila, int posicionColumna)
        {
            var request = new MovimientoRequest(partidaId, jugador, posicionFila, posicionColumna);

            try
            {
                var response = await httpClient.PostAsJsonAsync("api/Movimientos", request);
                response.EnsureSuccessStatusCode();
                return new Resource<MovimientoResponse>.Success(null!);
            }
            catch (HttpRequestException ex)
            {
                return new Resource<MovimientoResponse>.Error($"Error de red: {ex.Message}");
            }
            catch (NotSupportedException)
            {
                return new Resource<MovimientoResponse>.Error("Respuesta inválida del servidor.");
            }
        }
    }
}

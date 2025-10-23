﻿using System.Net.Http.Json;
using RegistroJugadores.Shared;
using RegistroJugadores.Shared.Dtos;

namespace RegistroDeJugadores.BlazorWassm.Services;

public class PartidasApiService (HttpClient httpClient) : IPartidasApiService
{
    public async Task<Resource<List<PartidasResponse>>> GetPartidasAsync()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<PartidasResponse>>("api/Partidas");
            return new Resource<List<PartidasResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<PartidasResponse>>.Error(ex.Message);
        }
    }

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

    public async Task<Resource<PartidasResponse>> PostPartida(int jugador1, int jugador2)
    {
        var request = new PartidasRequest(jugador1, jugador2);

        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Partidas", request);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<PartidasResponse>();
            return new Resource<PartidasResponse>.Success(created!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<PartidasResponse>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<PartidasResponse>.Error("Respuesta inválida del servidor.");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RegistroDeJugadores.DAL;
using RegistroDeJugadores.Models;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace RegistroDeJugadores.Services;

public class JugadoresService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Insertar(Jugadores jugador)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Jugadores.Add(jugador);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Jugadores jugador)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(jugador);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int jugadorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores
            .AnyAsync(j => j.JugadorId == jugadorId);
    }

    public async Task<Jugadores?> Buscar(int jugadorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores
            .FirstOrDefaultAsync(j => j.JugadorId == jugadorId);
    }

    public async Task<bool> Eliminar(int jugadorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores
            .AsNoTracking()
            .Where(j => j.JugadorId == jugadorId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Jugadores>> GetList(Expression<Func<Jugadores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Guardar(Jugadores jugador)
    {
        if (!await Existe(jugador.JugadorId) && !await NombreJugadorExiste(jugador.Nombre))
        {
            return await Insertar(jugador);
        }
        else
        {
            return await Modificar(jugador);
        }
    }

    public async Task<bool> NombreJugadorExiste(string nombre)
    {
        try
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .AnyAsync(j => j.Nombre.ToLower().Trim().Equals(nombre.ToLower().Trim()));
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al verificar la existencia del nombre del jugador", ex);
        }
    }
}

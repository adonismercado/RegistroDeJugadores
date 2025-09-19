using Microsoft.EntityFrameworkCore;
using RegistroDeJugadores.DAL;
using RegistroDeJugadores.Models;

namespace RegistroDeJugadores.Services;

public class MovimientosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Movimientos movimiento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Movimientos.Add(movimiento);
        return await contexto.SaveChangesAsync() > 0;
    }
}


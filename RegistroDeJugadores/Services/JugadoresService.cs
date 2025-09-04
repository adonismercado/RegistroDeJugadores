using Microsoft.EntityFrameworkCore;
using RegistroDeJugadores.DAL;
using RegistroDeJugadores.Models;
using System.Linq.Expressions;

namespace RegistroDeJugadores.Services
{
    public class JugadoresService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Insertar (Jugadores jugador)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Jugadores.Add(jugador);
            return await contexto.SaveChangesAsync() > 0;
        }
    }
}

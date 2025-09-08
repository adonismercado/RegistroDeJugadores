using Microsoft.EntityFrameworkCore;
using RegistroDeJugadores.DAL;
using RegistroDeJugadores.Models;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace RegistroDeJugadores.Services
{
    public class JugadoresService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Insertar(Jugadores jugador)
        {
            try
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.Jugadores.Add(jugador);
                return await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al insertar el jugador", ex);
            }
        }

        public async Task<bool> Modificar(Jugadores jugador)
        {
            try
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.Update(jugador);
                return await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al modificar el jugador", ex);
            }
        }

        public async Task<bool> Existe(int jugadorId)
        {
            try
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Jugadores
                    .AnyAsync(j => j.JugadorId == jugadorId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al verificar la existencia del jugador", ex);
            }
        }

        public async Task<Jugadores?> Buscar(int jugadorId)
        {
            try
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Jugadores
                    .FirstOrDefaultAsync(j => j.JugadorId == jugadorId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al buscar el jugador", ex);
            }
        }

        public async Task<bool> Eliminar(int jugadorId)
        {
            try
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Jugadores
                    .AsNoTracking()
                    .Where(j => j.JugadorId == jugadorId)
                    .ExecuteDeleteAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al eliminar el jugador", ex);
            }
        }

        public async Task<List<Jugadores>> GetList(Expression<Func<Jugadores, bool>> criterio)
        {
            try
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Jugadores
                    .Where(criterio)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener la lista de jugadores", ex);
            }
        }

        public async Task<bool> Guardar(Jugadores jugador)
        {
            try
            {
                var existeJugadorId = await Existe(jugador.JugadorId);
                var existeJugadorNombre = await NombreJugadorExiste(jugador.Nombre);

                if (!existeJugadorId && !existeJugadorNombre)
                {
                    return await Insertar(jugador);
                }
                else if (existeJugadorId && !existeJugadorNombre)
                {
                    return await Modificar(jugador);
                }
                else if (!existeJugadorId && existeJugadorNombre)
                {
                    throw new InvalidOperationException("El nombre del jugador ya existe.");
                }
                else
                {
                    throw new InvalidOperationException("El jugador con este ID y este nombre ya existe.");
                }
            } catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar el jugador", ex);
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

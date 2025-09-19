using RegistroDeJugadores.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroDeJugadores.DAL;

public class Contexto : DbContext
{
    public DbSet<Jugadores> Jugadores { get; set; }
    public DbSet<Partidas> Partidas { get; set; }
    public DbSet<Movimientos> Movimientos { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
}


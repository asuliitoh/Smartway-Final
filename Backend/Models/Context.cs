using Microsoft.EntityFrameworkCore;

namespace SmartwayFinal.Models;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Agente> Agentes { get; set; } = null!;
    public DbSet<Operacion> Operaciones { get; set; } = null!;
    public DbSet<Equipo> Equipos { get; set; } = null!;

}
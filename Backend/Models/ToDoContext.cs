using Microsoft.EntityFrameworkCore;

namespace SmartwayFinal.Models;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Agente> Agentes { get; set; } = null!;
}
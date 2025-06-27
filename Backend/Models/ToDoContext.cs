using Microsoft.EntityFrameworkCore;

namespace SmartwayFinal.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    public DbSet<Agente> Agentes { get; set; } = null!;
}
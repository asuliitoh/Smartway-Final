using Microsoft.EntityFrameworkCore;

namespace SmartwayFinal.Models;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Agente> Agentes { get; set; } = null!;
    public DbSet<Operacion> Operaciones { get; set; } = null!;
    public DbSet<Equipo> Equipos { get; set; } = null!;

    public DbSet<AgenteEquipo> AgenteEquipos {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Relacion Muchos a Muchos entre Agentes y Equipos
        modelBuilder.Entity<AgenteEquipo>()
        .HasKey(agenteEquipo => new { agenteEquipo.AgenteId, agenteEquipo.EquipoId });

        modelBuilder.Entity<Agente>()
            .HasMany(a => a.MiembroEquipos)
            .WithMany(e => e.Miembros)
            .UsingEntity<AgenteEquipo>(
                //Asociacion de clave ajena con entidad Equipo
                o => o.HasOne(agenteEquipo => agenteEquipo.Equipo) 
                .WithMany() //No hay navegación inversa
                .HasForeignKey(agenteEquipo => agenteEquipo.EquipoId),

                o => o.HasOne(agenteEquipo => agenteEquipo.Agente)
                .WithMany()
                .HasForeignKey(agenteEquipo => agenteEquipo.AgenteId)

            );

    
        modelBuilder.Entity<Equipo>()
            .HasOne(e => e.Owner)
            .WithMany(a => a.OwnerEquipos)
            .HasForeignKey(e => e.OwnerId);

        base.OnModelCreating(modelBuilder);
    }

    

        

}
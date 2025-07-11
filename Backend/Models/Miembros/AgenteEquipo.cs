namespace SmartwayFinal.Models;

public class AgenteEquipo
{
    public int AgenteId { get; set; }
    public Agente Agente { get; set; } = null!;

    public int EquipoId { get; set; }

    public Equipo Equipo { get; set; } = null!;

    public EstadoSolicitud Estado { get; set; }
}
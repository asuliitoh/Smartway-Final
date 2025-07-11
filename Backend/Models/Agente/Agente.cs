namespace SmartwayFinal.Models;

public class Agente
{

    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Password { get; set; }
    public string? Rango { get; set; }
    public bool Activo { get; set; }

    //Navegación
    public ICollection<Equipo> OwnerEquipos { get; set; } = [];

    //Navegación
    public ICollection<Equipo> MiembroEquipos { get; set; } = [];
    
}
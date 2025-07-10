namespace SmartwayFinal.Models;

public class Equipo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Especialidad { get; set; }

    //Navegación
    public ICollection<Operacion>? Operaciones { get; set; }
    
    //Clave ajena
    public int OwnerId { get; set; }

    //Navegación
    public Agente Owner { get; set; } = null!;

    //Navegación
    public ICollection<Agente> Miembros { get; set; } = [];

}
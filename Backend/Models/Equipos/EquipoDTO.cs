namespace SmartwayFinal.Models;

public class EquipoDTO
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Especialidad { get; set; }

    //Navegación
    public ICollection<OperacionEquipo> Operaciones { get; set; } = [];
    
    //Clave ajena
    public int OwnerId { get; set; }

    //Navegación
    public ICollection<MiembroEquipo> Miembros { get; set; } = [];

}
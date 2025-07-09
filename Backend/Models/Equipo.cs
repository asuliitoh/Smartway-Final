namespace SmartwayFinal.Models;

public class Equipo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Especialidad { get; set; }

    public ICollection<int>? OperacionesId { get; set; }
    
    public int? OwnerId { get; set; }

    public ICollection<int>? MemberId { get; set; }

}
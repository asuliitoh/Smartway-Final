namespace SmartwayFinal.Models;

public class Equipo
{
    public required int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Especialidad { get; set; }

    public ICollection<int>? OperacionesId { get; set; }
    
    public ICollection<int>? AgentesId { get; set; }

}
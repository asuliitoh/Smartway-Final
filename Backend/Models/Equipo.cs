namespace SmartwayFinal.Models;

public class Equipo
{
    public required int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Especialidad { get; set; }

    public ICollection<String>? OperacionesId { get; set; }
    
    public ICollection<String>? AgentesId { get; set; }

}
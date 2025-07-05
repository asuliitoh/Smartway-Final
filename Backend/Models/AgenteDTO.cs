namespace SmartwayFinal.Models;

public class AgenteDTO
{

    public required string Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Rango { get; set; }
    public bool Activo { get; set; }
    public string? EquipoId { get; set; }
}
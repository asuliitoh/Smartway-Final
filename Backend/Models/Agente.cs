namespace SmartwayFinal.Models;

public class Agente
{

    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Password { get; set; }
    public string? Rango { get; set; }
    public bool Activo { get; set; }

    public String? EquipoId { get; set; }
}
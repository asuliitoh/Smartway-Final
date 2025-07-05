namespace SmartwayFinal.Models;

public class Operacion
{
    public required string Id { get; set; }

    public string? Nombre { get; set; }

    public EstadoOperacion Estado { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

}
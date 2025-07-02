namespace SmartwayFinal.Models;

public class Operacion
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public EstadoOperacion Estado { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

}
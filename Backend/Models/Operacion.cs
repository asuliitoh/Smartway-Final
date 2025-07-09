using System.Text.Json.Serialization;

namespace SmartwayFinal.Models;

public class Operacion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EstadoOperacion Estado { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    

}
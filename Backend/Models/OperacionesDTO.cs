using System.Text.Json.Serialization;
namespace SmartwayFinal.Models;

public class OperacionDTO
{
    public string? Nombre { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EstadoOperacion Estado { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    

}
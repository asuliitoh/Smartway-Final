using System.Text.Json.Serialization;
using SmartwayFinal.Services;
namespace SmartwayFinal.Models;

public class CrearOperacion
{
    public string? Nombre { get; set; }

    [JsonConverter(typeof(EstadoOperacionJsonConverter))]
    public EstadoOperacion Estado { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    

}
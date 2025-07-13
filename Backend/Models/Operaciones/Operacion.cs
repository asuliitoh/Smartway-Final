using System.Text.Json.Serialization;
using SmartwayFinal.Services;

namespace SmartwayFinal.Models;

public class Operacion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    [JsonConverter(typeof(EstadoOperacionJsonConverter))]
    public EstadoOperacion Estado { get; set; }



    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime FechaInicio { get; set; }

    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime FechaFinal { get; set; }

    //Clave ajena
    public int? EquipoId { get; set; }

    //Clave ajena
    public int? CreadorId { get; set; }

    //Navegación
    public Equipo Equipo { get; set; } = null!;


}

using System.Text.Json;
using System.Text.Json.Serialization;
using SmartwayFinal.Models;

namespace SmartwayFinal.Services;

public class EstadoOperacionJsonConverter : JsonConverter<EstadoOperacion>
{
    public override EstadoOperacion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {

        string enumValue = reader.GetString()!;
        if (enumValue == "Activo") return EstadoOperacion.ACTIVO;
        else if (enumValue == "Planificado") return EstadoOperacion.PLANIFICADO;
        else if (enumValue == "Completado") return EstadoOperacion.COMPLETADO;
        throw new JsonException();
                
    }

    public override void Write(Utf8JsonWriter writer, EstadoOperacion value, JsonSerializerOptions options)
    {
        if (value is EstadoOperacion.ACTIVO) writer.WriteStringValue("Activo");
        else if (value is EstadoOperacion.PLANIFICADO) writer.WriteStringValue("Planificado");
        else writer.WriteStringValue("Completado");
    }
}
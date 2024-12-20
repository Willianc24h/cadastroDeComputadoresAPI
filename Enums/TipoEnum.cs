using System.Text.Json.Serialization;

namespace CadastroDeComputadores.Enums {
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum TipoEnum {
        Desktop,
        Monitor,
        Notebook,
    }
}

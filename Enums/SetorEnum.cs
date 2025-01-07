using System.Text.Json.Serialization;

namespace CadastroDeComputadores.Enums {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SetorEnum {
        Brava,
        Comercial,
        CRF,
        DaVita,
        Dinamicar,
        Droom,
        Financeiro,
        Operacoes,
        Planejamento,
        Qualidade,
        RH,
        TI
    }
}

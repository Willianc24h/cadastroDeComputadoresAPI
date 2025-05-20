using CadastroDeComputadores.Enums;
using System.ComponentModel.DataAnnotations;


public class CadastroModel {

    [Key]
    public string Tag { get; set; } = string.Empty; // Inicializado para evitar warnings
    public SetorEnum Setor { get; set; }
    public required string dataDeEntrada { get; set; } // Inicializado com valor padrão
    public string? dataDeSaida { get; set; } // Tornado anulável
    public TipoEnum Tipo { get; set; }
    public required string Usuario { get; set; }
    public string NFE { get; set; } = string.Empty; // Inicializado para evitar warnings
    public bool Ativo { get; set; } = true; // Inicializado com valor padrão
}

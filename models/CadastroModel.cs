using CadastroDeComputadores.Enums;
using System.ComponentModel.DataAnnotations;

public class CadastroModel {
    [Key]
    public int Id { get; set; }
    public string Tag { get; set; } = string.Empty;
    public SetorEnum Setor { get; set; }
    public required string dataDeEntrada { get; set; } = string.Empty; // Inicializado com valor padrão
    public string? dataDeSaida { get; set; }
    public required string SistemaOperacional { get; set; } = string.Empty; // Inicializado com valor padrão
    public required string Geracao { get; set; } = string.Empty; // Inicializado com valor padrão
    public TipoEnum Tipo { get; set; }
    public required string Usuario { get; set; } = string.Empty; // Inicializado com valor padrão
    public string NFE { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
}

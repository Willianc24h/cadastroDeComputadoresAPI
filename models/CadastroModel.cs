using CadastroDeComputadores.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeComputadores.models {
    public class CadastroModel {

        public SetorEnum Setor { get; set; }
        [Key]
        public string Tag { get; set; }
        public DateTime DataDeEntrada { get; set; }
        public DateTime? DataDeSaida { get; set; }
        public TipoEnum Tipo { get; set; }
        public string NFE { get; set; }
        public bool Ativo { get; set; }
    }
}

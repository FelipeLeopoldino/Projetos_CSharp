using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Domain.Models
{
    public abstract class Titulo
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [Key]
        public long IdNaturezaDeLancamento { get; set; }

        [Required]
        public NaturezaDeLancamento NaturezaDeLancamento { get; set; }

        [Required(ErrorMessage = "O campo de Descrição é obrigatorio")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo de ValorOriginal é obrigatorio")]
        public double ValorOriginal { get; set; }

        public string? Observacao { get; set; } = string.Empty;

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo de DataVencimeto é obrigatorio")]
        public DateTime DataVencimento { get; set; }

        public DateTime? DataInativacao { get; set; }

        public DateTime? DataReferencia { get; set; }

    }
}
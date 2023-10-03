using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Domain.Models
{
    public class Apagar : Titulo
    {
        [Required(ErrorMessage = "O campo de ValorPago é obrigatorio")]
        public double ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models
{
    public class TarefaModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da Tarefa!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a Descrição da Tarefa!")]
        public string Descricao { get; set; }

        public DateTime DataDeConclusao { get; set; }
    }
}

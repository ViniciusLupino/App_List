using System.ComponentModel;

namespace AppTarefas.Models
{
    public class Tarefa
    {
        public Guid TarefaId { get; set; }

        [DisplayName("Tarefa")]
        public string TarefaNome { get; set; }
        [DisplayName("Data inical")]
        public DateTime DataInicio { get; set; } = DateTime.Now;
        [DisplayName("Data final")]
        public DateTime? DataFim { get; set; }
        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        [DisplayName("Status")]
        public Guid? StatusId { get; set; }
        public Status? Status { get; set; }

    }
}

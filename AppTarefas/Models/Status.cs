using System.ComponentModel;

namespace AppTarefas.Models
{
    public class Status
    {
        public Guid StatusId { get; set; }
        [DisplayName("Status")]
        public string StatusNome { get; set; }
        public IEnumerable<Tarefa>? Tarefas { get; set; }
    }
}

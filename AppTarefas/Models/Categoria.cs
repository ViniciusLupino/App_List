using System.ComponentModel;

namespace AppTarefas.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        [DisplayName("Categoria")]
        public string CategoriaNome { get; set; }
        [DisplayName("Cor")]
        public string CategoriaCor { get; set; }

        public IEnumerable<Tarefa>? Tarefas { get; set; }
    }
}

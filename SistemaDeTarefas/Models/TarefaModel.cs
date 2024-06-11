using SistemaDeTarefas.Enum;

namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }

        //Propriedade do usuário do tipo model
        public virtual UsuarioModel? Usuario { get; set; }
    }
}

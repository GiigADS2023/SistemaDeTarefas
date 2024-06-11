using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interface
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorID(int id);
        Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa);
        Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int id);
        Task<bool> ApagarTarefa(int id);
    }
}

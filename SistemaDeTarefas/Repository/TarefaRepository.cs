using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interface;

namespace SistemaDeTarefas.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public TarefaRepository(SistemaTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<TarefaModel> BuscarPorID(int id)
        {
            return await _dbContext.Tarefa
                        .Include(x => x.Usuario)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefa
                        .Include(x => x.Usuario)
                        .ToListAsync();
        }

        public async Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa)
        {
            await _dbContext.Tarefa.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorID = await BuscarPorID(id);
            
            if (tarefaPorID == null)
            {
                throw new Exception($"Tarefa para o ID: {id}, não foi encontrado no banco de dados.");
            }
                tarefaPorID.Name = tarefa.Name;
                tarefaPorID.Description = tarefa.Description;
                tarefaPorID.Status = tarefa.Status;
                tarefaPorID.Usuario = tarefa.Usuario;

            _dbContext.Tarefa.Update(tarefaPorID);
            await _dbContext.SaveChangesAsync();

            return tarefaPorID;
        }

        public async Task<bool> ApagarTarefa(int id)
        {
            TarefaModel tarefaPorID = await BuscarPorID(id);

            if(tarefaPorID == null)
            {
                throw new Exception($"Tarefa para o ID:  {id}, não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefa.Remove(tarefaPorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

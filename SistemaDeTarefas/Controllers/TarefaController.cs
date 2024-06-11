using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository;
using SistemaDeTarefas.Repository.Interface;

namespace SistemaDeTarefas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository) 
        {
            _tarefaRepository = tarefaRepository;
        }
        //Buscar os usuários
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas() 
        {
            List<TarefaModel> tarefas = await _tarefaRepository.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorID(int id)
        {
            TarefaModel tarefa = await _tarefaRepository.BuscarPorID(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> CadastrarTarefa([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepository.AdicionarTarefa(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<ActionResult<TarefaModel>> AtualizarTarefa([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepository.AtualizarTarefa(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete]
        public async Task<ActionResult<TarefaModel>> ApagarTarefa(int id)
        {
            bool apagado = await _tarefaRepository.ApagarTarefa(id);
            return Ok(apagado);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // IMPORTANTE
    public class TarefasController : Controller
    {
        // usa do repository para atualizar no mongo
        private readonly TarefaRepository _repository;

        public TarefasController(TarefaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> Get()
        {
            var tarefas = await _repository.ObterTodasTarefasAsync();
            return Ok(tarefas);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Tarefa novaTarefa)
        {
            await _repository.CriarTarefaAsync(novaTarefa);
            return CreatedAtAction(nameof(Get), new { id = novaTarefa.Id }, novaTarefa);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            
            await _repository.DeletarAsync(id);

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStatus(string id, [FromBody] bool cancelado)
        {
            
            await _repository.AlterarStatusAsync(id, cancelado);

            //Retorna 204 NoContent (Sucesso, sem conteúdo para devolver)
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Tarefa tarefaAtualizada)
        {
            
            await _repository.AtualizarTotalAsync(id, tarefaAtualizada);

           
            return NoContent();
        }
    }
}

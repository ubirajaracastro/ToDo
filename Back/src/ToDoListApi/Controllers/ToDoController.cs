using Microsoft.AspNetCore.Mvc;
using ToDoListAplicacao.Contratos;
using ToDoListAplicacao.Dto;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {       
        public ITODoService _toDoService { get; }

        public ToDoController(ITODoService toDoService)
        {
            _toDoService = toDoService;
            
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {               
                var tarefas = await _toDoService.ObterTodasTarefasAsync();
                 if (tarefas == null) return NotFound("Nenhum tarefa encontrada.");

                return Ok(tarefas);


            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Erro ao tentar recuperar tarefas. Erro: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var tarefa = await _toDoService.ObterTarefaPorId(id);
                if (tarefa == null) return NotFound("Tarefa por Id não encontrada.");

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar recuperar tarefas. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var tarefa = await _toDoService.ObterTarefaPorId(id);
                if (tarefa == null) return NoContent();

                 return await _toDoService.ExcluirTarefa(id) 
                       ? Ok(new { message = "Deletado" }) 
                       : throw new Exception("Ocorreu um problema ao tentar deletar a tarefa.");

            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(ToDoDto model)
        {
            try
            {
                var tarefa = await _toDoService.CriarTarefa(model);
                if (tarefa == null) return NoContent();
                
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar adicionar tarefa. Erro: {ex.Message}");
            }
        }


        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, ToDoDto model)
        {
            try
            {                
                var tarefa = await _toDoService.AtualizarTarefa(id, model);
                if (tarefa == null) return NoContent();

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500,
                    $"Erro ao tentar atualizar taefa. Erro: {ex.Message}");
            }
        }


        [HttpPut("{finalizaTarefa}")]
        public async Task<ActionResult> FinalizaTarefa(int id)
        {
            try
            {
                var tarefa = await _toDoService.FinalizarTarefa(id);
                if (tarefa == null) return NoContent();

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500,
                    $"Erro ao tentar atualizar taefa. Erro: {ex.Message}");
            }
        }

    }
}
using ToDoListAplicacao.Dto;

namespace ToDoListAplicacao.Contratos
{
    public interface ITODoService
    {
        Task<ToDoDto> CriarTarefa(ToDoDto model);
        Task<ToDoDto> AtualizarTarefa(int tarefaId, ToDoDto model);

        Task<ToDoDto> FinalizarTarefa(int tarefaId);
        Task<bool> ExcluirTarefa(int tarefaId);
        Task<ToDoDto[]> ObterTodasTarefasAsync();
        Task<ToDoDto> ObterTarefaPorId(int tarefaId);
        
    }
}
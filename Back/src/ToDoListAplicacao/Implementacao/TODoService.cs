using AutoMapper;
using ToDoListAplicacao.Contratos;
using ToDoListAplicacao.Dto;
using ToDoListDominio;
using ToDoListPersistencia.Contratos;

namespace ToDoListAplicacao.Implementacao
{
    public class TODoService : ITODoService

    { 
       public IGeralPersistencia _geralPersist { get; }
       public IToDoPersistencia _todoPersist { get; }   
       private readonly IMapper _mapper;

        public TODoService(IGeralPersistencia geralPersis,IMapper mapper,IToDoPersistencia todoPersist )
        {
            _mapper = mapper;
            _geralPersist = geralPersis;
            _todoPersist = todoPersist;
        }
        public async Task<ToDoDto> AtualizarTarefa(int tarefaId, ToDoDto model)
        {
             try
            {
                ToDo? tarefa = await _todoPersist.ObterTarefaPorIdAsync(tarefaId);
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                                model.Id = tarefa.Id;
                #pragma warning restore CS8602 // Dereference of a possibly null reference.


                _mapper.Map(model, tarefa);
                _geralPersist.Update<ToDo>(tarefa);

                await _geralPersist.SaveChangesAsync();    
                var tarefaRet = await _todoPersist.ObterTarefaPorIdAsync(model.Id);

                return _mapper.Map<ToDoDto>(tarefaRet);
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ToDoDto> CriarTarefa(ToDoDto model)
        {
             try    
            {
                var tarefa = _mapper.Map<ToDo>(model);
                _geralPersist.Add<ToDo>(tarefa);
                await _geralPersist.SaveChangesAsync();

                var tarefaretorno = await  _todoPersist.ObterTarefaPorIdAsync(model.Id);
                
                return _mapper.Map<ToDoDto>(tarefaretorno);                 

             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       


        }

        public async Task<bool> ExcluirTarefa(int tarefaId)
        {
             try
            {
                var tarefa = await _todoPersist.ObterTarefaPorIdAsync(tarefaId);
                if (tarefa == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<ToDo>(tarefa);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ToDoDto> ObterTarefaPorId(int tarefaId)
        {
             try
            {
                var tarefa = await _todoPersist.ObterTarefaPorIdAsync(tarefaId);                
                return _mapper.Map<ToDoDto>(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ToDoDto[]> ObterTodasTarefasAsync()
        {
           try
           {
            
             var tarefas = await _todoPersist.ObterTodasTaefasAsync();               
             return _mapper.Map<ToDoDto[]>(tarefas);

           }
           catch (System.Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

        public async Task<ToDoDto> FinalizarTarefa(int tarefaId)
        {
             try
            {
                ToDo? tarefa =  _todoPersist.MarcarCompletada(tarefaId,true);

                if(tarefa!=null)
                   tarefa.Finalizada=true;

                // #pragma warning disable CS8604 // Possible null reference argument.
                // _geralPersist.Update<ToDo>(tarefa);
                // #pragma warning restore CS8604 // Possible null reference argument.

                //await _geralPersist.SaveChangesAsync();    
                var tarefaRet = await _todoPersist.ObterTarefaPorIdAsync(tarefa.Id);

                return _mapper.Map<ToDoDto>(tarefaRet);
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
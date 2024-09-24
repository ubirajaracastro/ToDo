using Microsoft.EntityFrameworkCore;
using ToDoListDominio;
using ToDoListPersistencia.Contexto;
using ToDoListPersistencia.Contratos;

namespace ToDoListPersistencia.Implementacao
{
    public class ToDoPersistencia : IToDoPersistencia
    {
       private readonly ToDoListDBContext _contexto;

        public ToDoPersistencia(ToDoListDBContext contexto)
        {
            _contexto = contexto;
        }

        public ToDo? MarcarCompletada(int id, bool completa)
        {
            ToDo? todo = _contexto.tblToDo.Where(e => e.Id == id).FirstOrDefault();

            if (todo != null)
            {
                todo.Finalizada = completa;
                _contexto.tblToDo.Update(todo);
                _contexto.SaveChanges();

            }

            ToDo? tarefa = _contexto.tblToDo.AsNoTracking().Where(e => e.Id == id).FirstOrDefault();
            return tarefa;

        }

        public async Task<ToDo?> ObterTarefaPorIdAsync(int id)
        {
              IQueryable<ToDo> query = _contexto.tblToDo.AsNoTracking().Where(e => e.Id == id);
              return await query.FirstOrDefaultAsync();
        }

        public async Task<ToDo[]> ObterTodasTaefasAsync()
        {
            IQueryable<ToDo> query = _contexto.tblToDo.AsNoTracking();
            query = query.AsNoTracking().OrderBy(e => e.Id);
                        
            return await query.ToArrayAsync();

        }
    }
}
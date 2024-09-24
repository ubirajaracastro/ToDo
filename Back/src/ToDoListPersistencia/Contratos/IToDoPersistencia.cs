using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListDominio;

namespace ToDoListPersistencia.Contratos
{
    public interface IToDoPersistencia
    {
        Task<ToDo[]> ObterTodasTaefasAsync();
        Task<ToDo?> ObterTarefaPorIdAsync(int id);
        ToDo? MarcarCompletada(int id, bool completa);
    }
}
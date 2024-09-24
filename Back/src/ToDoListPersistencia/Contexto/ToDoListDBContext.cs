using Microsoft.EntityFrameworkCore;
using ToDoListDominio;

namespace ToDoListPersistencia.Contexto
{
    public class ToDoListDBContext:DbContext
    {
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options): base(options)
        {
            
        }

         public DbSet<ToDo> tblToDo { get; set; }
        
    }
}
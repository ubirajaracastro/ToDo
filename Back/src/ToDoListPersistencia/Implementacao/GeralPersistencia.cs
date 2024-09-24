using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListPersistencia.Contexto;
using ToDoListPersistencia.Contratos;

namespace ToDoListPersistencia.Implementacao
{
    public class GeralPersistencia:IGeralPersistencia
    {
         private readonly ToDoListDBContext _context;

        public GeralPersistencia(ToDoListDBContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
             _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
             return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        
    }
}
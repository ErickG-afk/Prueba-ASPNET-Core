using Prueba_ASPNET_Core.Modelos;
using System.Data.Entity;

namespace Prueba_ASPNET_Core.Data
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ToDoContext _context;

        public ToDoTaskRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoTasks>> GetAllAsync()
        {
            return await _context.Tasks.Include(t => t.category).ToListAsync();
        }

        public async Task<ToDoTasks> GetByIdAsync(int id)
        {
            return await _context.Tasks.Include(t => t.TaskId)
                                           .FirstOrDefaultAsync(t => t.TaskId == id);
        }

        public async Task<ToDoTasks> AddAsync(ToDoTasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<ToDoTasks> UpdateAsync(ToDoTasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}

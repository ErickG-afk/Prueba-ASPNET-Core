using Prueba_ASPNET_Core.Modelos;

namespace Prueba_ASPNET_Core.Data
{
    public interface IToDoTaskRepository
    {
        Task<IEnumerable<ToDoTasks>> GetAllAsync();
        Task<ToDoTasks> GetByIdAsync(int id);
        Task<ToDoTasks> AddAsync(ToDoTasks task);
        Task<ToDoTasks> UpdateAsync(ToDoTasks task);
        Task DeleteAsync(int id);
    }
}

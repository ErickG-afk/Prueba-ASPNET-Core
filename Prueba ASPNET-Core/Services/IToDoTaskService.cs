using Prueba_ASPNET_Core.Modelos;

namespace Prueba_ASPNET_Core.Services
{
    public interface IToDoTaskService
    {
        Task<IEnumerable<ToDoTasks>> GetAllTasksAsync();
        Task<ToDoTasks> GetTaskByIdAsync(int id);
        Task<ToDoTasks> CreateTaskAsync(ToDoTasks task);
        Task<ToDoTasks> UpdateTaskAsync(ToDoTasks task);
        Task DeleteTaskAsync(int id);
    }
}

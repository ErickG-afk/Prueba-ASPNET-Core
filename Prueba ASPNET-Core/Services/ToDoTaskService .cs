using Prueba_ASPNET_Core.Data;
using Prueba_ASPNET_Core.Modelos;

namespace Prueba_ASPNET_Core.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _repository;

        public ToDoTaskService(IToDoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ToDoTasks>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ToDoTasks> GetTaskByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ToDoTasks> CreateTaskAsync(ToDoTasks task)
        {
            return await _repository.AddAsync(task);
        }

        public async Task<ToDoTasks> UpdateTaskAsync(ToDoTasks task)
        {
            return await _repository.UpdateAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

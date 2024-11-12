using Microsoft.AspNetCore.Mvc;
using Prueba_ASPNET_Core.Modelos;
using Prueba_ASPNET_Core.Services;

namespace Prueba_ASPNET_Core.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly IToDoTaskService _service;

        public ToDoTaskController(IToDoTaskService service)
        {
            _service = service;
        }

        // Ver todas las tareas
        public async Task<IActionResult> Index()
        {
            var tasks = await _service.GetAllTasksAsync();
            return View(tasks); // Devuelve la vista que muestra todas las tareas
        }

        // Ver una tarea por su id
        public async Task<IActionResult> Details(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task); // Devuelve la vista de detalles
        }

        // Crear una nueva tarea
        public IActionResult Create()
        {
            return View(); // Muestra el formulario para crear una nueva tarea
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoTasks task)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateTaskAsync(task);
                return RedirectToAction(nameof(Index)); // Redirige al listado de tareas
            }
            return View(task); // Si hay errores, muestra el formulario con los errores
        }

        // Editar una tarea existente
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task); // Devuelve el formulario para editar la tarea
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoTasks task)
        {
            if (id != task.TaskId) return BadRequest();

            //Validar que al actualizar una tarea a IsCompleted, la fecha de finalización (DueDate) sea pasada.
            if (task.IsCompleted && task.DueDate < DateTime.UtcNow)
                return BadRequest("Task can only be completed once due date is past");

            if (ModelState.IsValid)
            {
                await _service.UpdateTaskAsync(task);
                return RedirectToAction(nameof(Index)); // Redirige al listado de tareas
            }
            return View(task); // Si hay errores, muestra el formulario con los errores
        }

        // Eliminar una tarea
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task); // Muestra el formulario de confirmación para eliminar
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index)); // Redirige al listado de tareas
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Prueba_ASPNET_Core.Modelos;
using Prueba_ASPNET_Core.Services;

namespace Prueba_ASPNET_Core.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // Ver todas las categorías
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllCategoriesAsync();

            return View(categories); // Devuelve la vista que muestra todas las categorías
        }

        // Ver una categoría por su id
        public async Task<IActionResult> Details(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return View(category); // Devuelve la vista de detalles
        }

        // Crear una nueva categoría
        public IActionResult Create()
        {
            return View(); // Muestra el formulario para crear una nueva categoría
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateCategoryAsync(category);
                return RedirectToAction(nameof(Index)); // Redirige al listado de categorías
            }
            return View(category); // Si hay errores, muestra el formulario con los errores
        }

        // Editar una categoría existente
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return View(category); // Devuelve el formulario para editar la categoría
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId) return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.UpdateCategoryAsync(category);
                return RedirectToAction(nameof(Index)); // Redirige al listado de categorías
            }
            return View(category); // Si hay errores, muestra el formulario con los errores
        }

        // Eliminar una categoría
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return View(category); // Muestra el formulario de confirmación para eliminar
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index)); // Redirige al listado de categorías
        }
    }

}


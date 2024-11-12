using Prueba_ASPNET_Core.Data;
using Prueba_ASPNET_Core.Modelos;

namespace Prueba_ASPNET_Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await _repository.AddAsync(category);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            return await _repository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

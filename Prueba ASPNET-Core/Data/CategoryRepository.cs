using Prueba_ASPNET_Core.Modelos;
using System.Data.Entity;

namespace Prueba_ASPNET_Core.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ToDoContext _context;

        public CategoryRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Tasks).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Tasks)
                                            .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prueba_ASPNET_Core.Modelos;

namespace Prueba_ASPNET_Core.Pages.Categorias
{
    public class DetailsModel : PageModel
    {
        private readonly Prueba_ASPNET_Core.Modelos.ToDoContext _context;

        public DetailsModel(Prueba_ASPNET_Core.Modelos.ToDoContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}

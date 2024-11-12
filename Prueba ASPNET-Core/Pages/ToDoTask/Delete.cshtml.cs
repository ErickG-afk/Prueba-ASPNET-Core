using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prueba_ASPNET_Core.Modelos;

namespace Prueba_ASPNET_Core.Pages.ToDoTask
{
    public class DeleteModel : PageModel
    {
        private readonly Prueba_ASPNET_Core.Modelos.ToDoContext _context;

        public DeleteModel(Prueba_ASPNET_Core.Modelos.ToDoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoTasks ToDoTasks { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todotasks = await _context.Tasks.FirstOrDefaultAsync(m => m.TaskId == id);

            if (todotasks == null)
            {
                return NotFound();
            }
            else
            {
                ToDoTasks = todotasks;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todotasks = await _context.Tasks.FindAsync(id);
            if (todotasks != null)
            {
                ToDoTasks = todotasks;
                _context.Tasks.Remove(ToDoTasks);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

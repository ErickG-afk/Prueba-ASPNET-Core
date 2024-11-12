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
    public class DetailsModel : PageModel
    {
        private readonly Prueba_ASPNET_Core.Modelos.ToDoContext _context;

        public DetailsModel(Prueba_ASPNET_Core.Modelos.ToDoContext context)
        {
            _context = context;
        }

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
    }
}

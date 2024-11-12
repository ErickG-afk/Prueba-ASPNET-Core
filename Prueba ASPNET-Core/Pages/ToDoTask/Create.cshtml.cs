using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prueba_ASPNET_Core.Modelos;

namespace Prueba_ASPNET_Core.Pages.ToDoTask
{
    public class CreateModel : PageModel
    {
        private readonly Prueba_ASPNET_Core.Modelos.ToDoContext _context;

        public CreateModel(Prueba_ASPNET_Core.Modelos.ToDoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return Page();
        }

        [BindProperty]
        public ToDoTasks ToDoTasks { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(ToDoTasks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly Prueba_ASPNET_Core.Modelos.ToDoContext _context;

        public IndexModel(Prueba_ASPNET_Core.Modelos.ToDoContext context)
        {
            _context = context;
        }

        public IList<ToDoTasks> ToDoTasks { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ToDoTasks = await _context.Tasks
                .Include(t => t.category).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Prueba_ASPNET_Core.Modelos
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoTasks> Tasks { get; set; }

    }
}

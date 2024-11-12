
using Microsoft.EntityFrameworkCore;

namespace DataBase.Models
{
    public class ToDoContext: DbContext
    {
        public ToDoContext(Microsoft.EntityFrameworkCore.DbContextOptions<ToDoContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}

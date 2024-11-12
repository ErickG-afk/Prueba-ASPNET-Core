using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_ASPNET_Core.Modelos
{
    public class ToDoTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        //Añadir las comprobaciones de longitud de caracteres 
        [MaxLength(100, ErrorMessage = "The title can not be longer than 100 letters")]
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        [Range(1, 5, ErrorMessage = "Priority must be between 1 and 5.")]
        public int Prority { get; set; }
        public bool IsCompleted { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category category { get; set; }
    }
}

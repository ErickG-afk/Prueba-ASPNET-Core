using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_ASPNET_Core.Modelos
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        //Añadir las comprobaciones de longitud de caracteres 
        [MaxLength(100, ErrorMessage = "The name can not be longer than 100 letters")]
        public string Name { get; set; }

        public virtual ICollection<ToDoTasks> Tasks { get; set; }
    }
}

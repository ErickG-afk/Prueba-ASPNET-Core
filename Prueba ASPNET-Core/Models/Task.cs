using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int Prority { get; set; }
        public bool IsCompleted { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category category { get; set; }
    }
}

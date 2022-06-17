using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDatabase.Models
{
   public class Component
    {
        public int Id { get; set; }
        [Required]
        public string ComponentName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime TimeComp { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<ProductComponent> ProductComponents { get; set; }

        
    }
}

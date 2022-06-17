using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDatabase.Models
{
  public  class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Type { get; set; }
        [ForeignKey("ProductId")]

        public Dictionary<int, int> ProductComponents { get; set; }
    }
}

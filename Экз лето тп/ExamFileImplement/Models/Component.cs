using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamFileImplement.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public DateTime TimeComp { get; set; }
    }
}

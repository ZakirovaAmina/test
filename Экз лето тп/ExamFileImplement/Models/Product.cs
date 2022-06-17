using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamFileImplement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public Dictionary<int, int> ProductComponents { get; set; }
    }
}

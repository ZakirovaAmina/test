using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContracts.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string ProductName { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        public DateTime TimeProd { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}

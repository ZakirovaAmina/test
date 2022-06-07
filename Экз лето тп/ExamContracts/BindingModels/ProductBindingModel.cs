using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContracts.BindingModels
{
    public class ProductBindingModel
    {
        public int? Id { get; set; }
        public string product { get; set; }
        public string Type { get; set; }
        public DateTime TimeProd { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}

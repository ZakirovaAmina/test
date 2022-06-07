using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContracts.BindingModels
{
    public class ComponentBindingModel
    {
        public int? Id { get; set; }
        public string ComponentName { get; set; }
        public decimal Price { get; set; }
        public string Firma { get; set; }
        public DateTime TimeComp { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ExamContracts.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Дата сборки")]
        public DateTime TimeComp { get; set; }
    }
}

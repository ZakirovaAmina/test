using ExamListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamListImplements
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Product> Products { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Products = new List<Product>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)

            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDatabase.Models
{
   public class ProductComponent
    {
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int ComponentId { get; set; }
		[Required]
		public int Count { get; set; }
		public virtual Component Component { get; set; }
		public virtual Product Product { get; set; }
	}
}

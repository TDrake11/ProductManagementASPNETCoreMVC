using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }

		[MaxLength(15)]
		public string CategoryName { get; set; }

		public ICollection<Product>? Products { get; set; }
	}
}

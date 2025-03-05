using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Entities
{
	public partial class Category
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; } = null!;

		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Entities
{
	public partial class Product
	{
		public int ProductId { get; set; }

		public string ProductName { get; set; } = null!;

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public short? UnitsInStock { get; set; }

		public decimal? UnitPrice { get; set; }

		public virtual Category? Category { get; set; } = null!;
	}
}

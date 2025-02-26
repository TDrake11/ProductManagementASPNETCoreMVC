using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories.Data;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Repositories.CategoryRepository
{

	public class CategoryRepository : ICategoryRepository
	{
		private readonly MyStoreDbContext _context;

		public CategoryRepository(MyStoreDbContext context) // Inject đúng cách
		{
			_context = context;
		}
		public List<Category> GetCategories()
		{
			var listCategory = new List<Category>();
			try
			{
				listCategory = _context.Categories.ToList();
			}catch (Exception ex) {
				throw new Exception(ex.Message);
			}
			return listCategory;
		}
	}
}

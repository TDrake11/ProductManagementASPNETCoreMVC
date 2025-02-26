using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories.Repositories.CategoryRepository;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Services.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		public readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public List<Category> GetCategories()
		{
			return _categoryRepository.GetCategories();
		}
	}
}

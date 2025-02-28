using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories.Interfaces;
using PRN222.Lab1.Repositories.Repositories.CategoryRepository;


namespace PRN222.Lab1.Services.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<List<Category>> GetCategories()
		{
			return await _unitOfWork.Repository<Category>().GetList().ToListAsync();
		}
	}
}

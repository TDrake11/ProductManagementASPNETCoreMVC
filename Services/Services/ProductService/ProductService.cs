using PRN222.Lab1.Repositories.Repositories.ProductRepository;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRN222.Lab1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PRN222.Lab1.Services.Services.ProductService
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void DeleteProduct(Product product)
		{
			_unitOfWork.Repository<Product>().Delete(product);
			_unitOfWork.SaveChanges();
		}

		public async Task<Product?> GetProductById(int id)
		{
			return await _unitOfWork.Repository<Product>().GetByIdAsync(id);
		}

		public async Task<List<Product>> GetProducts()
		{
			return await _unitOfWork.Repository<Product>().GetList().ToListAsync();
		}

		public async Task CreateProduct(Product product)
		{
			await _unitOfWork.Repository<Product>().AddAsync(product);
			_unitOfWork.SaveChanges();
		}

		public void UpdateProduct(Product product)
		{
			_unitOfWork.Repository<Product>().Update(product);
			_unitOfWork.SaveChanges();
		}
	}
}

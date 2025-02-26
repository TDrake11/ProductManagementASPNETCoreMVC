using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories.Data;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Repositories.ProductRepository
{
	public class ProductRepository : IProductRepository
	{
		private readonly MyStoreDbContext _context;

		public ProductRepository(MyStoreDbContext context) // Inject đúng cách
		{
			_context = context;
		}
		public void DeleteProduct(Product product)
		{
			try
			{
				var productDelete = _context.Products.SingleOrDefault(p=>p.ProductId == product.ProductId);
				_context.Products.Remove(productDelete);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Product GetProductById(int id)
		{
			return _context.Products.FirstOrDefault(p => p.ProductId.Equals(id));
		}

		public List<Product> GetProducts()
		{
			var listProduct = new List<Product>();
			try
			{
				listProduct = _context.Products.Include(p=>p.Category).ToList();
			}
			catch (Exception ex) 
			{
				throw new Exception(ex.Message);

			}
			return listProduct;
		}

		public void SaveProduct(Product product)
		{
			try
			{
				_context.Products.Add(product);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void UpdateProduct(Product product)
		{
			try
			{
				_context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}

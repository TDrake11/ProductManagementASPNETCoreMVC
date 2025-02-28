using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Services.Services.ProductService
{
	public interface IProductService
	{
		Task CreateProduct(Product product);
		void DeleteProduct(Product product);
		void UpdateProduct(Product product);
		Task<List<Product>> GetProducts();
		Task<Product?> GetProductById(int id);

	}
}

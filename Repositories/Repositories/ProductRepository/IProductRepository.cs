using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Repositories.ProductRepository
{
	public interface IProductRepository
	{
		List<Product> GetProducts();
		void SaveProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(Product product);
		Product GetProductById(int id);
	}
}

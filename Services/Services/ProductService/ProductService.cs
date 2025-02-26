using PRN222.Lab1.Repositories.Repositories.ProductRepository;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Services.Services.ProductService
{
	public class ProductService : IProductService
	{
		public readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public void DeleteProduct(Product product)
		{
			_productRepository.DeleteProduct(product);
		}

		public Product GetProductById(int id)
		{
			return _productRepository.GetProductById(id);
		}

		public List<Product> GetProducts()
		{
			return _productRepository.GetProducts();
		}

		public void SaveProduct(Product product)
		{
			_productRepository.SaveProduct(product);
		}

		public void UpdateProduct(Product product)
		{
			_productRepository.UpdateProduct(product);
		}
	}
}

using Microsoft.Extensions.DependencyInjection;
using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly MyStoreDbContext _context;
		private readonly IServiceProvider _serviceProvider;
		private Dictionary<Type, object> _repositories;

		public UnitOfWork(MyStoreDbContext context, IServiceProvider serviceProvider)
		{
			_context = context;
			_serviceProvider = serviceProvider;
		}
		//public IGenericRepository<T> Repository<T>() where T : class
		//{
		//	if(_repositories == null)
		//	{
		//		_repositories = new Dictionary<Type, object>();
		//	}
		//	var type = typeof(T);
		//	if (!_repositories.TryGetValue(type, out var repository))
		//	{
		//		var repositoryType = typeof(GenericRepository<>);
		//		var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(type), _context);
		//		_repositories.Add(type, repositoryInstance);
		//	}
		//	return (IGenericRepository<T>)_repositories[type];
		//}

		public IGenericRepository<T> Repository<T>() where T : class
		{
			return _serviceProvider.GetRequiredService<IGenericRepository<T>>();
		}

		public void SaveChanges()
		{
		  _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}

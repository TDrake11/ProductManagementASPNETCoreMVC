using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T?> GetByIdAsync(int id);
		IQueryable<T> GetList();
		Task AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}

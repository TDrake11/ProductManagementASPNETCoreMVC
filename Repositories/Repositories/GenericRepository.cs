﻿using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly MyStoreDbContext _context;

		public GenericRepository(MyStoreDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public IQueryable<T> GetList()
		{
			var result = _context.Set<T>();
			return result;
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}	
	}
}

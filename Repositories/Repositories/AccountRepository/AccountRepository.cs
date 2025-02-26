using PRN222.Lab1.Repositories.Data;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Repositories.AccountRepository
{
	public class AccountRepository : IAccountRepository

	{
		private readonly MyStoreDbContext _context;

		public AccountRepository(MyStoreDbContext context) // Inject đúng cách
		{
			_context = context;
		}
		public AccountMember GetAccountMember(string email)
		{
			return _context.AccountMember.FirstOrDefault(c => c.EmailAddress.Equals(email));
		}
	}
}

using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories.Repositories.AccountRepository;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Services.Services.AccountService
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public AccountMember GetAccountMember(string email)
		{
			return _accountRepository.GetAccountMember(email);
		}
	}
}

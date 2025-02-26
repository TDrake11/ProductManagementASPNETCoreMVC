using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Repositories.AccountRepository
{
	public interface IAccountRepository
	{
		AccountMember GetAccountMember(string accountId);
	}
}

using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories.Interfaces;

namespace PRN222.Lab1.Services.Services.AccountService
{
	public class AccountService : IAccountService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AccountService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public AccountMember GetAccountMember(string email)
		{
			return _unitOfWork.Repository<AccountMember>().GetList().Where(a => a.EmailAddress.Equals(email)).FirstOrDefault();
		}
	}
}

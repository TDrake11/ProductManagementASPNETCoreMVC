using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Entities
{
	public partial class AccountMember
	{
		public string MemberId { get; set; } = null!;

		public string MemberPassword { get; set; } = null!;

		public string FullName { get; set; } = null!;

		public string EmailAddress { get; set; } = null!;

		public int MemberRole { get; set; }
	}

}

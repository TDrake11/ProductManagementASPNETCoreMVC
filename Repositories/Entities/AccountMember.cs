using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Entities
{
	public class AccountMember
	{
		[MaxLength(20)]
		public string MemberId { get; set; }
		[MaxLength(80)]
		public string MemberPassword { get; set; }
		[MaxLength(80)]
		public string FullName { get; set; }
		[MaxLength(100)]
		public string EmailAddress { get; set; }
		public int MemberRole { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace AnnualTournament.Areas.Admin.Models
{
	public class AdminUserCreateViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
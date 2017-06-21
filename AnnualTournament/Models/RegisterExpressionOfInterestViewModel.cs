using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnnualTournament.Models
{
	public class RegisterExpressionOfInterestViewModel
	{
		[DisplayName("Manager")]
		[Required(ErrorMessage = "Please Enter a Manager")]
		public string TeamManagerName { get; set; }

		[Required(ErrorMessage = "Please Enter a Team Name")]
		[DisplayName("Team Name")]
		public string TeamName { get; set; }

		[Required(ErrorMessage = "Please Enter a Email")]
		[DisplayName("Email")]
		public string TeamEmailAddress { get; set; }

		[Required(ErrorMessage = "Please Enter a Phone Number")]
		[DisplayName("Mobile")]
		public string MobileNumber { get; set; }

		[Required(ErrorMessage = "Please Enter an Alternate Contact")]
		[DisplayName("Alternate Contact")]
		public string AlternateContactName { get; set; }

		[Required(ErrorMessage = "Please Enter an Alternate Phone Number")]
		[DisplayName("Alternate Mobile")]
		public string AlternateMobileNumber { get; set; }

		[Required(ErrorMessage = "Please Enter an Alternate Email")]
		[DisplayName("Alternate Email")]
		public string AlternateEmail { get; set; }
	}
}
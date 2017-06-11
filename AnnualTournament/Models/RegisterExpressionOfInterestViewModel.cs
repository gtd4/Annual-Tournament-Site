using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AnnualTournament.Models
{
	public class RegisterExpressionOfInterestViewModel
	{
		[DisplayName("Manager")]
		public string TeamManagerName { get; set; }

		[DisplayName("Team Name")]
		public string TeamName { get; set; }

		[DisplayName("Email")]
		public string TeamEmailAddress { get; set; }

		[DisplayName("Mobile")]
		public string MobileNumber { get; set; }

		[DisplayName("Alternate Contact")]
		public string AlternateContactName { get; set; }

		[DisplayName("Alternate Mobile")]
		public string AlternateMobileNumber { get; set; }

		[DisplayName("Alternate Email")]
		public string AlternateEmail { get; set; }
	}
}
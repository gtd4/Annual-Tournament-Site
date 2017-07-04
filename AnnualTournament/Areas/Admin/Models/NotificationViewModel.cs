using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnnualTournament.Areas.Admin.Models
{
	public class NotificationViewModel
	{
		[Required]
		[Display(Name = "Subject")]
		public string Subject { get; set; }

		[Required]
		[Display(Name = "Message")]
		public string Message { get; set; }
	}
}
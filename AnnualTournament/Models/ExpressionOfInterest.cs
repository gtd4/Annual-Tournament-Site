using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AnnualTournament.Models
{
	public class ExpressionOfInterest
	{
		public string TeamManagerName { get; set; }
		public string TeamName { get; set; }
		public string TeamEmailAddress { get; set; }
		public string MobileNumber { get; set; }
		public string AlternateContactName { get; set; }
		public string AlternateMobileNumber { get; set; }
		public string AlternateEmail { get; set; }

		public bool HasPaid { get; set; }

		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }

		public List<string> Errors { get; }

		public ExpressionOfInterest()
		{
			Errors = new List<string>();
		}

		public bool ValidateExpressionOfInterest()
		{
			var isvalid = true;
			if (string.IsNullOrEmpty(TeamEmailAddress))
			{
				isvalid = false;
				Errors.Add("Email Address is Empty");
			}

			if (string.IsNullOrEmpty(TeamManagerName))
			{
				isvalid = false;
				Errors.Add("Manager is Empty");
			}

			if (!IsValidEmail())
			{
				isvalid = false;
				Errors.Add("Email Address is not Valid");
			}

			return isvalid;
		}

		public bool IsValidEmail()
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(TeamEmailAddress);
				return addr.Address == TeamEmailAddress;
			}
			catch
			{
				return false;
			}
		}

		public void RegisterExpressionOfInterest()
		{
		}
	}
}
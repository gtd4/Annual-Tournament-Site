using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AnnualTournament.Common.Models
{
	public class ExpressionOfInterest
	{
		public int ExpressionOfInterestId { get; set; }
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
			if (string.IsNullOrEmpty(TeamName))
			{
				isvalid = false;
				Errors.Add("Team Name is Empty");
			}
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

			if (string.IsNullOrEmpty(AlternateContactName))
			{
				isvalid = false;
				Errors.Add("Alternate Contact is Empty");
			}

			if (string.IsNullOrEmpty(AlternateEmail))
			{
				isvalid = false;
				Errors.Add("Alternate Email is Empty");
			}

			if (string.IsNullOrEmpty(AlternateMobileNumber))
			{
				isvalid = false;
				Errors.Add("Alternate Mobile is Empty");
			}

			if (!IsValidEmail(TeamEmailAddress))
			{
				isvalid = false;
				Errors.Add("Email Address is not Valid");
			}

			if (!IsValidEmail(AlternateEmail))
			{
				isvalid = false;
				Errors.Add("Alternate Email is not Valid");
			}

			return isvalid;
		}

		public bool IsValidEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
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
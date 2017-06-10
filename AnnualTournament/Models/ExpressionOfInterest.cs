using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualTournament.Models
{
	public class ExpressionOfInterest
	{
		public string TeamManagerName { get; set; }
		public string TeamName { get; set; }
		public string TeamEmailAddress { get; set; }
		public bool HasPaid { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }

		public bool ValidateExpressionOfInterest()
		{
			var isvalid = true;
			if(string.IsNullOrEmpty(TeamEmailAddress))
			{
				isvalid = false;
			}

			if(string.IsNullOrEmpty(TeamManagerName))
			{
				isvalid = false;
			}

			if(!IsValidEmail())
			{
				isvalid = false;
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
using AnnualTournament.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnnualTournament.Common.Models
{
	public class ExpressionOfInterestContext
	{
		public DbSet<ExpressionOfInterest> ExpressionsOfInterest { get; set; }
	}
}
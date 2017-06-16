using AnnualTournament.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AnnualTournament.Common.Models
{
	public class ExpressionOfInterestContext : DbContext
	{
		public ExpressionOfInterestContext() : base("AnnualTournament")
		{
		}

		public DbSet<ExpressionOfInterest> ExpressionsOfInterest { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
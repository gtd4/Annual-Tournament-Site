using AnnualTournament.Models;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AnnualTournament.Tests.Models
{
    [Binding]
    public class TestExpressionOfInterestSteps
    {
		private ExpressionOfInterest eoi;
		private bool validateResult;
		private bool isEmailValid;

		public TestExpressionOfInterestSteps()
		{
			eoi = new ExpressionOfInterest();
		}

        [Given(@"I have an EOI with the team name missing")]
        public void GivenIHaveAnEOIWithTheTeamNameMissing()
        {
			eoi.TeamName = string.Empty;
        }
        
        [Given(@"I have an EOI with the team contact email missing")]
        public void GivenIHaveAnEOIWithTheTeamContactEmailMissing()
        {
			eoi.TeamEmailAddress = string.Empty;
        }
        
        [Given(@"I have an email address of gav\.com")]
        public void GivenIHaveAnEmailAddressOfGav_Com()
        {
			eoi.TeamEmailAddress = "gav.com";
        }
        
        [Given(@"I have an EOI with the team manager name as Gavin")]
        public void GivenIHaveAnEOIWithTheTeamManagerNameAsGavin()
        {
			eoi.TeamManagerName = "Gavin";
        }
        
        [Given(@"the team as Saiyans")]
        public void GivenTheTeamAsSaiyans()
        {
			eoi.TeamName = "Saiyans";
        }
        
        [Given(@"the email address as gtd(.*)@gmail\.com")]
        public void GivenTheEmailAddressAsGtdGmail_Com(int p0)
        {
			eoi.TeamEmailAddress = "gtd005@gmail.com";
        }
        
        [When(@"I try to validate my EOI")]
        public void WhenITryToValidateMyEOI()
        {
			validateResult = eoi.ValidateExpressionOfInterest();
        }
        
        [When(@"I try to validate the address")]
        public void WhenITryToValidateTheAddress()
        {
			isEmailValid = eoi.IsValidEmail();
        }
        
        [Then(@"the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {

			Assert.IsFalse(validateResult);
        }

		[Then(@"the result should be true")]
		public void ThenTheResultShouldBeTrue()
		{
			Assert.IsTrue(validateResult);
		}

	}
}

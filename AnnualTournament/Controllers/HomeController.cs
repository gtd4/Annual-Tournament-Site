using AnnualTournament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnnualTournament.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Register()
		{
			ViewBag.Message = "Your Registration page.";
			var eoi = new ExpressionOfInterest();

			return View(eoi);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterExpressionOfInterestViewModel eoiViewModel)
		{
			if (ModelState.IsValid)
			{
				var expressionOfInterest = new ExpressionOfInterest
				{
					TeamName = eoiViewModel.TeamName,
					TeamEmailAddress = eoiViewModel.TeamEmailAddress,
					TeamManagerName = eoiViewModel.TeamManagerName,
					HasPaid = false,
					DateCreated = DateTime.Now,
					DateModified = DateTime.Now,
				};

				//Save to Db
				//var result = await UserManager.CreateAsync(user, model.Password);
				//if (result.Succeeded)
				if (expressionOfInterest.ValidateExpressionOfInterest())
				{
					//await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

					// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
					// Send an email with this link
					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction("RegisterSuccess", "Home");
				}
				//AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(eoiViewModel);
		}
	}
}
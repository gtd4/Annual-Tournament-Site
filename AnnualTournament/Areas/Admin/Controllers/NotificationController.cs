using AnnualTournament.Areas.Admin.Models;
using AnnualTournament.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AnnualTournament.Areas.Admin.Controllers
{
	[Authorize]
	public class NotificationController : Controller
	{
		// GET: Admin/Notification
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult SendNotification(string message)
		{
			var fromAddress = new MailAddress(ConfigurationManager.AppSettings["AdminEmail"], ConfigurationManager.AppSettings["AdminName"]);

			using (var msg = new MailMessage())
			{
				msg.Body = message;
				msg.From = fromAddress;

				if (ModelState.IsValid)
				{
					using (var db = new ExpressionOfInterestContext())
					{
						foreach (var eoi in db.ExpressionsOfInterest)
						{
							msg.To.Add(eoi.TeamEmailAddress);
						}
					}

					var smtp = new SmtpClient
					{
						Host = "smtp.gmail.com",
						Port = 587,
						EnableSsl = true,
						DeliveryMethod = SmtpDeliveryMethod.Network,
						UseDefaultCredentials = false,
						Credentials = new NetworkCredential(fromAddress.Address, "tournament")
					};

					{
						smtp.Send(msg);
					}
				}
			}
			return RedirectToAction("Index", "ExpressionOfInterests");
		}
	}
}
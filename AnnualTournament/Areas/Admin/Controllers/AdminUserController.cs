//using AnnualTournament.Areas.Admin.Models;
//using AnnualTournament.Models;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace AnnualTournament.Areas.Admin.Controllers
//{
//	[Authorize]
//	public class AdminUserController : Controller
//	{
//		private ApplicationDbContext db = new ApplicationDbContext();
//		private ApplicationUserManager _userManager;
//		private ApplicationSignInManager _signInManager;
//		private const string tempAdminPassword = "Password1";

//		public AdminUserController()
//		{
//		}

//		public AdminUserController(ApplicationUserManager userManager)
//		{
//			_userManager = userManager;
//		}

//		public ApplicationUserManager UserManager
//		{
//			get
//			{
//				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//			}
//			private set
//			{
//				_userManager = value;
//			}
//		}

//		public ApplicationSignInManager SignInManager
//		{
//			get
//			{
//				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
//			}
//			private set
//			{
//				_signInManager = value;
//			}
//		}

//		// GET: Admin/AdminUser
//		public async Task<ActionResult> Index()
//		{
//			return View(await UserManager.Users.ToListAsync());
//		}

//		public ActionResult Create()
//		{
//			return View();
//		}

//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<ActionResult> Create(AdminUserCreateViewModel model)
//		{
//			if (ModelState.IsValid)
//			{
//				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
//				var result = await UserManager.CreateAsync(user, tempAdminPassword);
//				if (result.Succeeded)
//				{
//					// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
//					// Send an email with this link
//					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
//					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
//					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

//					return RedirectToAction("Index", "AdminUser");
//				}

//				AddErrors(result);
//			}

//			// If we got this far, something failed, redisplay form
//			return View(model);
//		}

//		// GET: Admin/ExpressionOfInterests/Edit/5
//		public async Task<ActionResult> Edit(string id)
//		{
//			if (id == null)
//			{
//				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//			}
//			var user = await UserManager.FindByIdAsync(id);
//			if (user == null)
//			{
//				return HttpNotFound();
//			}
//			return View(user);
//		}

//		// POST: Admin/AdminUser/Edit/5
//		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
//		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<ActionResult> Edit([Bind(Include = "Id,Email,PhoneNumber")] ApplicationUser adminUser)
//		{
//			if (ModelState.IsValid)
//			{
//				var user = UserManager.FindById(adminUser.Id);
//				user.Email = adminUser.Email;
//				user.UserName = adminUser.Email;
//				user.PhoneNumber = adminUser.PhoneNumber;

//				var result = await UserManager.UpdateAsync(user);

//				if (result.Succeeded)
//				{
//					return RedirectToAction("Index");
//				}
//			}
//			return View(adminUser);
//		}

//		public async Task<ActionResult> ProfilePage()
//		{
//			var user = await UserManager.FindByNameAsync(User.Identity.Name);
//			return View(user);
//		}

//		//
//		// GET: /Manage/ChangePassword
//		public ActionResult ChangePassword()
//		{
//			return View();
//		}

//		//
//		// POST: /Manage/ChangePassword
//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
//		{
//			if (!ModelState.IsValid)
//			{
//				return View(model);
//			}
//			var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
//			if (result.Succeeded)
//			{
//				var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
//				if (user != null)
//				{
//					await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
//				}
//				return RedirectToAction("ProfilePage", new { Message = ManageMessageId.ChangePasswordSuccess });
//			}
//			AddErrors(result);
//			return View(model);
//		}

//		/*// GET: Admin/ExpressionOfInterests/Delete/5
//		public async Task<ActionResult> Delete(int? id)
//		{
//			if (id == null)
//			{
//				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//			}
//			ExpressionOfInterest expressionOfInterest = await db.ExpressionsOfInterest.FindAsync(id);
//			if (expressionOfInterest == null)
//			{
//				return HttpNotFound();
//			}
//			return View(expressionOfInterest);
//		}

//		// POST: Admin/ExpressionOfInterests/Delete/5
//		[HttpPost, ActionName("Delete")]
//		[ValidateAntiForgeryToken]
//		public async Task<ActionResult> DeleteConfirmed(int id)
//		{
//			ExpressionOfInterest expressionOfInterest = await db.ExpressionsOfInterest.FindAsync(id);
//			db.ExpressionsOfInterest.Remove(expressionOfInterest);
//			await db.SaveChangesAsync();
//			return RedirectToAction("Index");
//		}
//		*/

//		protected override void Dispose(bool disposing)
//		{
//			if (disposing)
//			{
//				db.Dispose();
//			}
//			base.Dispose(disposing);
//		}

//		private void AddErrors(IdentityResult result)
//		{
//			foreach (var error in result.Errors)
//			{
//				ModelState.AddModelError("", error);
//			}
//		}
//	}

//	public enum ManageMessageId
//	{
//		AddPhoneSuccess,
//		ChangePasswordSuccess,
//		SetTwoFactorSuccess,
//		SetPasswordSuccess,
//		RemoveLoginSuccess,
//		RemovePhoneSuccess,
//		Error
//	}
//}
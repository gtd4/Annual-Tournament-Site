using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnnualTournament.Common.Models;

namespace AnnualTournament.Areas.Admin.Controllers
{
	[Authorize]
	public class ExpressionOfInterestsController : Controller
	{
		private ExpressionOfInterestContext db = new ExpressionOfInterestContext();

		// GET: Admin/ExpressionOfInterests

		public async Task<ActionResult> Index()
		{
			return View(await db.ExpressionsOfInterest.ToListAsync());
		}

		// GET: Admin/ExpressionOfInterests/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ExpressionOfInterest expressionOfInterest = await db.ExpressionsOfInterest.FindAsync(id);
			if (expressionOfInterest == null)
			{
				return HttpNotFound();
			}
			return View(expressionOfInterest);
		}

		// GET: Admin/ExpressionOfInterests/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/ExpressionOfInterests/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "ExpressionOfInterestId,TeamManagerName,TeamName,TeamEmailAddress,MobileNumber,AlternateContactName,AlternateMobileNumber,AlternateEmail,HasPaid,DateCreated,DateModified")] ExpressionOfInterest expressionOfInterest)
		{
			if (ModelState.IsValid)
			{
				db.ExpressionsOfInterest.Add(expressionOfInterest);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(expressionOfInterest);
		}

		// GET: Admin/ExpressionOfInterests/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ExpressionOfInterest expressionOfInterest = await db.ExpressionsOfInterest.FindAsync(id);
			if (expressionOfInterest == null)
			{
				return HttpNotFound();
			}
			return View(expressionOfInterest);
		}

		// POST: Admin/ExpressionOfInterests/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "ExpressionOfInterestId,TeamManagerName,TeamName,TeamEmailAddress,MobileNumber,AlternateContactName,AlternateMobileNumber,AlternateEmail,HasPaid,DateCreated,DateModified")] ExpressionOfInterest expressionOfInterest)
		{
			if (ModelState.IsValid)
			{
				db.Entry(expressionOfInterest).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(expressionOfInterest);
		}

		// GET: Admin/ExpressionOfInterests/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ExpressionOfInterest expressionOfInterest = await db.ExpressionsOfInterest.FindAsync(id);
			if (expressionOfInterest == null)
			{
				return HttpNotFound();
			}
			return View(expressionOfInterest);
		}

		// POST: Admin/ExpressionOfInterests/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			ExpressionOfInterest expressionOfInterest = await db.ExpressionsOfInterest.FindAsync(id);
			db.ExpressionsOfInterest.Remove(expressionOfInterest);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
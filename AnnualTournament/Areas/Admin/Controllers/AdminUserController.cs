using AnnualTournament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnnualTournament.Areas.Admin.Controllers
{
	[Authorize]
	public class AdminUserController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Admin/AdminUser
		public async Task<ActionResult> Index()
		{
			return View(await db.Users.ToListAsync());
		}
	}
}
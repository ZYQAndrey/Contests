using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using MSContests.Models;

namespace MSContests.Controllers
{
    public class UniversalAppsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UniversalApps
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Index()
        {
            var appsList = (from app in await db.UniversalApps.ToListAsync()
                            select new UniversalListViewModel()
                            {
                                Approved = app.Approved,
                                Id = app.Id,
                                W8AppName = app.W8AppName,
                                RegisterDate = app.RegisterDate
                            }).ToList();
            return View(appsList);
        }

        // GET: UniversalApps/Details/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversalApp universalApp = await db.UniversalApps.FindAsync(id);

            var app = new UniversalAppDetailsViewModel()
            {
                Id = universalApp.Id,
                W8AppName = universalApp.W8AppName,
                W8AppUrl = universalApp.W8AppUrl,
                WpAppName = universalApp.WpAppName,
                WpAppUrl = universalApp.WpAppUrl,
                Comments = universalApp.Comments,
                FirstName = universalApp.Competitor.FirstName,
                LastName = universalApp.Competitor.LastName,
                Position = universalApp.Competitor.Position,
                AreYouAStudent = universalApp.Competitor.AreYouAStudent,
                City = universalApp.Competitor.City,
                Country = universalApp.Competitor.Country,
                Email = universalApp.Competitor.Email,
                Phone = universalApp.Competitor.Phone,
                Approved = universalApp.Approved,
                ApprovalDate = universalApp.ApprovalDate,
                RegisterDate = universalApp.RegisterDate
            };

            return View(app);
        }

        // GET: UniversalApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversalApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LastName,FirstName,Email,Phone,Country,City,Position,AreYouAStudent,W8AppName,W8AppUrl,WpAppName,WpAppUrl,Comments")] UniversalAppViewModel universalApp)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Сообщение: Отлично! Проверка на антиспам пройдена!";
                var user = new Competitor()
                {
                    FirstName = universalApp.FirstName,
                    LastName = universalApp.LastName,
                    AreYouAStudent = universalApp.AreYouAStudent,
                    City = universalApp.City,
                    Country = universalApp.Country,
                    Email = universalApp.Email,
                    Id = Guid.NewGuid(),
                    Phone = universalApp.Phone,
                    Position = universalApp.Position
                };

                db.Competitors.Add(user);

                var application = new UniversalApp()
                {
                    Id = Guid.NewGuid(),
                    Approved = false,
                    Competitor = user,
                    Comments = universalApp.Comments,
                    W8AppName = universalApp.W8AppName,
                    W8AppUrl = universalApp.W8AppUrl,
                    WpAppName = universalApp.WpAppName,
                    WpAppUrl = universalApp.WpAppUrl,
                    RegisterDate = DateTime.Now,
                    ApprovalDate = DateTime.Now

                };
                db.UniversalApps.Add(application);

                await db.SaveChangesAsync();

                return RedirectToAction("Success", "UniversalApps", new { id = application.Id });
            }
            TempData["ErrorMessage"] = "Ошибка: антиспам проверка не пройдена.";
            return View(universalApp);
        }

        // GET: UniversalApps/Edit/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var universalApp = await db.UniversalApps.FindAsync(id);
            var view = new UniversalEditAppViewModel()
            {
                W8AppName = universalApp.W8AppName,
                WpAppName = universalApp.WpAppName,
                Approved = universalApp.Approved,
                Id = universalApp.Id
            };

            if (universalApp == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        // POST: UniversalApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Approved,W8AppName,WpAppName")]UniversalEditAppViewModel universalApp)
        {
            if (ModelState.IsValid)
            {
                var app = db.UniversalApps.Find(universalApp.Id);
                app.Approved = universalApp.Approved;
                if (universalApp.Approved) app.ApprovalDate = DateTime.Now;

                db.Entry(app).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(universalApp);
        }

        // GET: UniversalApps/Delete/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversalApp universalApp = await db.UniversalApps.FindAsync(id);
            if (universalApp == null)
            {
                return HttpNotFound();
            }
            return View(universalApp);
        }

        // POST: UniversalApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            UniversalApp universalApp = await db.UniversalApps.FindAsync(id);
            db.UniversalApps.Remove(universalApp);
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

        //
        //GET: /MultiPlatformApps/Success
        public ActionResult Success(Guid id)
        {
            var reguest = db.UniversalApps.Find(id);
            ViewBag.BackLink = "Universality";
            return View(reguest);
        }
    }
}

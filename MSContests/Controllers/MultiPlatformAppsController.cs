using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSContests.Models;

namespace MSContests.Controllers
{
    public class MultiPlatformAppsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MultiPlatformApps
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Index()
        {
            var appsList = (from app in await db.MultiPlatformApps.ToListAsync()
                select new MultiPlatformListViewModel()
                {
                    Approved = app.Approved, Id = app.Id, W8AppName = app.W8AppName, RegisterDate = app.RegisterDate
                }).ToList();
            return View(appsList);
        }

        // GET: MultiPlatformApps/Details/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiPlatformApp multiPlatformApp = await db.MultiPlatformApps.FindAsync(id);

            var app = new MultiplePlutformAppDetailsViewModel()
            {
                Id = multiPlatformApp.Id,
                AppleAppName = multiPlatformApp.AppleAppName,
                AppleAppUrl = multiPlatformApp.AppleAppUrl,
                GoogleAppName = multiPlatformApp.GoogleAppName,
                GoogleAppUrl = multiPlatformApp.GoogleAppUrl,
                W8AppName = multiPlatformApp.W8AppName,
                W8AppUrl = multiPlatformApp.W8AppUrl,
                WpAppName = multiPlatformApp.WpAppName,
                WpAppUrl = multiPlatformApp.WpAppUrl,
                Comments = multiPlatformApp.Comments,
                FirstName = multiPlatformApp.Competitor.FirstName,
                LastName = multiPlatformApp.Competitor.LastName,
                Position = multiPlatformApp.Competitor.Position,
                AreYouAStudent = multiPlatformApp.Competitor.AreYouAStudent,
                City = multiPlatformApp.Competitor.City,
                Country = multiPlatformApp.Competitor.Country,
                Email = multiPlatformApp.Competitor.Email,
                Phone = multiPlatformApp.Competitor.Phone,
                Approved = multiPlatformApp.Approved,
                ApprovalDate = multiPlatformApp.ApprovalDate,
                RegisterDate = multiPlatformApp.RegisterDate
            };

            return View(app);
        }

        // GET: MultiPlatformApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultiPlatformApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [CaptchaMvc.Attributes.CaptchaVerify("Ошибка: антиспам проверка не пройдена.")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LastName,FirstName,Email,Phone,Country,City,Position,AreYouAStudent,W8AppName,W8AppUrl,WpAppName,WpAppUrl,AppleAppName,AppleAppUrl,GoogleAppName,GoogleAppUrl,Comments")] MultiPlatformAppViewModel multiPlatformApp)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Сообщение: Отлично! Проверка на антиспам пройдена!";
                var user = new Competitor()
                {
                    FirstName = multiPlatformApp.FirstName,
                    LastName = multiPlatformApp.LastName,
                    AreYouAStudent = multiPlatformApp.AreYouAStudent,
                    City = multiPlatformApp.City,
                    Country = multiPlatformApp.Country,
                    Email = multiPlatformApp.Email,
                    Id = Guid.NewGuid(),
                    Phone = multiPlatformApp.Phone,
                    Position = multiPlatformApp.Position
                };

                db.Competitors.Add(user);

                var application = new MultiPlatformApp()
                {
                    Id = Guid.NewGuid(),
                    Approved = false,
                    Competitor = user,
                    Comments = multiPlatformApp.Comments,
                    AppleAppName = multiPlatformApp.AppleAppName,
                    AppleAppUrl = multiPlatformApp.AppleAppUrl,
                    GoogleAppName = multiPlatformApp.GoogleAppName,
                    GoogleAppUrl = multiPlatformApp.GoogleAppUrl,
                    W8AppName = multiPlatformApp.W8AppName,
                    W8AppUrl = multiPlatformApp.W8AppUrl,
                    WpAppName = multiPlatformApp.WpAppName,
                    WpAppUrl = multiPlatformApp.WpAppUrl,
                    RegisterDate = DateTime.Now,
                    ApprovalDate = DateTime.Now

                };
                db.MultiPlatformApps.Add(application);

                await db.SaveChangesAsync();

                return RedirectToAction("Success", "MultiPlatformApps", new { id = application.Id });
            }
            TempData["ErrorMessage"] = "Ошибка: антиспам проверка не пройдена.";
            return View(multiPlatformApp);
        }

        // GET: MultiPlatformApps/Edit/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiPlatformApp multiPlatformApp = await db.MultiPlatformApps.FindAsync(id);
            var view = new MultiPlatformEditAppViewModel()
            {
                AppleAppName = multiPlatformApp.AppleAppName,
                GoogleAppName = multiPlatformApp.GoogleAppName,
                W8AppName = multiPlatformApp.W8AppName,
                WpAppName = multiPlatformApp.WpAppName,
                Approved = multiPlatformApp.Approved,
                Id = multiPlatformApp.Id
            };

            if (multiPlatformApp == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        // POST: MultiPlatformApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Approved,W8AppName,WpAppName,AppleAppName,GoogleAppName")]MultiPlatformEditAppViewModel multiPlatformApp)
        {
            if (ModelState.IsValid)
            {
                var app = db.MultiPlatformApps.Find(multiPlatformApp.Id);
                app.Approved = multiPlatformApp.Approved;
                if (multiPlatformApp.Approved) app.ApprovalDate = DateTime.Now;

                db.Entry(app).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(multiPlatformApp);
        }

        // GET: MultiPlatformApps/Delete/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiPlatformApp multiPlatformApp = await db.MultiPlatformApps.FindAsync(id);
            if (multiPlatformApp == null)
            {
                return HttpNotFound();
            }
            return View(multiPlatformApp);
        }

        // POST: MultiPlatformApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            MultiPlatformApp multiPlatformApp = await db.MultiPlatformApps.FindAsync(id);
            db.MultiPlatformApps.Remove(multiPlatformApp);
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
            var reguest = db.MultiPlatformApps.Find(id);
            ViewBag.BackLink = "Universality";
            return View(reguest);
        }
    }
}

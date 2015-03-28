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
    public class GamesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Games
        public async Task<ActionResult> Index()
        {
            var appsList = (from app in await _db.Games.ToListAsync()
                            select new GameListViewModel()
                            {
                                Approved = app.Approved,
                                Id = app.Id,
                                AppName = app.WpAppName,
                                RegisterDate = app.RegisterDate
                            }).ToList();
            return View(appsList);
        }

        // GET: Games/Details/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = await _db.Games.FindAsync(id);

            var app = new GameDetailViewModel()
            {
                Id = game.Id,
                AppleAppName = game.AppleAppName,
                AppleAppUrl = game.AppleAppUrl,
                GoogleAppName = game.GoogleAppName,
                GoogleAppUrl = game.GoogleAppUrl,
                W8AppName = game.W8AppName,
                W8AppUrl = game.W8AppUrl,
                XboxAppName = game.XboxAppName,
                XboxAppUrl = game.XboxAppUrl,
                WpAppName = game.WpAppName,
                WpAppUrl = game.WpAppUrl,
                Comments = game.Comments,
                FirstName = game.Competitor.FirstName,
                LastName = game.Competitor.LastName,
                Position = game.Competitor.Position,
                AreYouAStudent = game.Competitor.AreYouAStudent,
                City = game.Competitor.City,
                Country = game.Competitor.Country,
                Email = game.Competitor.Email,
                Phone = game.Competitor.Phone,
                Approved = game.Approved,
                ApprovalDate = game.ApprovalDate,
                RegisterDate = game.RegisterDate
            };

            return View(app);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaMvc.Attributes.CaptchaVerify("Ошибка: антиспам проверка не пройдена.")]
        public async Task<ActionResult> Create(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Сообщение: Отлично! Проверка на антиспам пройдена!";
                var user = new Competitor()
                {
                    FirstName = game.FirstName,
                    LastName = game.LastName,
                    AreYouAStudent = game.AreYouAStudent,
                    City = game.City,
                    Country = game.Country,
                    Email = game.Email,
                    Id = Guid.NewGuid(),
                    Phone = game.Phone,
                    Position = game.Position
                };

                _db.Competitors.Add(user);

                var newGame = new Game()
                {
                    Id = Guid.NewGuid(),
                    Approved = false,
                    Competitor = user,
                    Comments = game.Comments,
                    AppleAppName = game.AppleAppName,
                    AppleAppUrl = game.AppleAppUrl,
                    GoogleAppName = game.GoogleAppName,
                    GoogleAppUrl = game.GoogleAppUrl,
                    W8AppName = game.W8AppName,
                    W8AppUrl = game.W8AppUrl,
                    WpAppName = game.WpAppName,
                    WpAppUrl = game.WpAppUrl,
                    XboxAppName = game.XboxAppName,
                    XboxAppUrl = game.XboxAppUrl,
                    RegisterDate = DateTime.Now,
                    ApprovalDate = DateTime.Now

                };
                _db.Games.Add(newGame);

                await _db.SaveChangesAsync();

                return RedirectToAction("Success", "games", new { id = newGame.Id });
            }
            TempData["ErrorMessage"] = "Ошибка: антиспам проверка не пройдена.";

            return View(game);
        }

        // GET: Games/Edit/5
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = await _db.Games.FindAsync(id);
            var view = new GameEditViewModel()
            {
                AppleAppName = game.AppleAppName,
                GoogleAppName = game.GoogleAppName,
                W8AppName = game.W8AppName,
                WpAppName = game.WpAppName,
                XboxAppName = game.XboxAppName,
                Approved = game.Approved,
                Id = game.Id
            };

            return View(view);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "a.v.andreev@hotmail.com")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Approved")]GameEditViewModel game)
        {
            if (ModelState.IsValid)
            {
                var app = _db.Games.Find(game.Id);
                app.Approved = game.Approved;
                if (game.Approved) app.ApprovalDate = DateTime.Now;

                _db.Entry(app).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }


        // GET: Games/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await _db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Game game = await _db.Games.FindAsync(id);
            _db.Games.Remove(game);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //
        //GET: /Games/Success
        public ActionResult Success(Guid id)
        {
            var reguest = _db.Games.Find(id);
            ViewBag.BackLink = "Games";
            return View(reguest);
        }
    }
}

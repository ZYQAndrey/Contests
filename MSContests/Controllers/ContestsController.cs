using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSContests.Models;

namespace MSContests.Controllers
{
    public class ContestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Contests/

        public ActionResult Nauryz()
        {
            var finishDate = Convert.ToDateTime("2013/03/23");
            var startDate = finishDate.AddDays(-52);
            ViewBag.Count = db.Requests.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<Request>();
            return View();
        }

        public ActionResult List(string finishDate)
        {
            ViewBag.BackLink = "NauryzCompleted";
            var finishDateTime = Convert.ToDateTime(finishDate);
            var startDate = finishDateTime.AddDays(-52);
            var allApps = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDateTime) < 0 )).ToList() : new List<Request>();
            return View(allApps);
        }

        public ActionResult NauryzCompleted()
        {
            var finishDate = Convert.ToDateTime("2013/03/23");
            var startDate = finishDate.AddDays(-52);
            ViewBag.Count = db.Requests.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(4).ToList() : new List<Request>();
            return View();
        }

        public ActionResult ListSummer(string finishDate)
        {
            ViewBag.BackLink = "SunnySummerCompleted";
            var finishDateTime = Convert.ToDateTime(finishDate);
            var startDate = finishDateTime.AddDays(-90);
            var allApps = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDateTime) < 0)).ToList() : new List<Request>();
            return View(allApps);
        }
        
        public ActionResult SunnySummer()
        {
            var finishDate = Convert.ToDateTime("2013/06/30");
            var startDate = finishDate.AddDays(-90);
            ViewBag.Count = db.Requests.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<Request>();
            return View();
        }
        
        public ActionResult SunnySummerCompleted()
        {
            var finishDate = Convert.ToDateTime("2013/06/30");
            var startDate = finishDate.AddDays(-90);
            ViewBag.Count = db.Requests.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<Request>();
            return View();
        }

        public ActionResult FallWinter()
        {
            var finishDate = Convert.ToDateTime("2013/12/31");
            var startDate = finishDate.AddDays(-63);
            ViewBag.Count = db.Requests.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<Request>();
            return View();
        }

        public ActionResult FallWinterList(string finishDate)
        {
            ViewBag.BackLink = "FallWinterCompleted";
            var finishDateTime = Convert.ToDateTime(finishDate);
            var startDate = finishDateTime.AddDays(-63);
            var allApps = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDateTime) < 0)).ToList() : new List<Request>();
            return View(allApps);
        }

        public ActionResult FallWinterCompleted()
        {
            var finishDate = Convert.ToDateTime("2013/12/31");
            var startDate = finishDate.AddDays(-63);
            ViewBag.Count = db.Requests.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.Requests.Count() != 0 ? db.Requests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<Request>();
            return View();
        }

        public ActionResult Kolesa()
        {
            var finishDate = Convert.ToDateTime("2014/01/31");
            var startDate = finishDate.AddDays(-50);
            ViewBag.Count = db.UploadRequests.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.UploadRequests.Count() != 0 ? db.UploadRequests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<UploadRequest>();
            return View();
        }

        public ActionResult KolesaCompleted()
        {
            return View();
        }

        public ActionResult KolesaList(string finishDate)
        {
            ViewBag.BackLink = "Kolesa";
            var finishDateTime = Convert.ToDateTime(finishDate);
            var startDate = finishDateTime.AddDays(-50);
            var allApps = db.UploadRequests.Count() != 0 ? db.UploadRequests.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDateTime) < 0)).ToList() : new List<UploadRequest>();
            return View(allApps);
        }

        public ActionResult Universality()
        {
            var finishDate = Convert.ToDateTime("2014/11/30");
            var startDate = finishDate.AddDays(-138);
            var countU = db.UniversalApps.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAddedU = db.UniversalApps.Count() != 0 ? db.UniversalApps.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<UniversalApp>();
            var countM = db.MultiPlatformApps.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAddedM = db.MultiPlatformApps.Count() != 0 ? db.MultiPlatformApps.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<MultiPlatformApp>();
            ViewBag.Count = countM + countU;
            return View();
        }

        public ActionResult UniversalityList(string finishDate)
        {
            ViewBag.BackLink = "Universality";
            var finishDateTime = Convert.ToDateTime(finishDate);
            var startDate = finishDateTime.AddDays(-138);
            ViewBag.allAppsU = db.UniversalApps.Count() != 0 ? db.UniversalApps.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDateTime) < 0)).ToList() : new List<UniversalApp>();
            ViewBag.allAppsM = db.MultiPlatformApps.Count() != 0 ? db.MultiPlatformApps.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDateTime) < 0)).ToList() : new List<MultiPlatformApp>();
            return View();
        }

        public ActionResult UniversalityCompleted()
        {
            var finishDate = Convert.ToDateTime("2014/11/30");
            var startDate = finishDate.AddDays(-138);
            var countU = db.UniversalApps.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAddedU = db.UniversalApps.Count() != 0 ? db.UniversalApps.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<UniversalApp>();
            var countM = db.MultiPlatformApps.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAddedM = db.MultiPlatformApps.Count() != 0 ? db.MultiPlatformApps.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<MultiPlatformApp>();
            ViewBag.Count = countM + countU;
            return View();
        }

        public ActionResult Games()
        {
            var finishDate = Convert.ToDateTime("2015/03/31");
            var startDate = finishDate.AddDays(-62);
            var count = db.Games.Count(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0));
            ViewBag.LastAdded = db.Games.Count() != 0 ? db.Games.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDate) < 0)).Take(10).ToList() : new List<Game>();
            ViewBag.Count = count;
            return View();
        }

        public ActionResult GamesList(string finishDate)
        {
            ViewBag.BackLink = "Games";
            var finishDateTime = Convert.ToDateTime(finishDate);
            var startDate = finishDateTime.AddDays(-62);
            ViewBag.allApps = db.Games.Count() != 0 ? db.Games.OrderByDescending(d => d.RegisterDate).Where(d => d.Approved && (d.RegisterDate.CompareTo(startDate) > 0 && d.RegisterDate.CompareTo(finishDateTime) < 0)).ToList() : new List<Game>();
            return View();
        }

        public ActionResult KazReg()
        {
            return View();
        }
    }
}

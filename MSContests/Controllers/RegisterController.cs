using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using MSContests.Models;

namespace MSContests.Controllers
{
    public class RegisterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //
        //GET: /Conditions/

        public ActionResult Conditions()
        {
            ViewBag.BackLink = "Nauryz";
            return View();
        }

        //
        //GET: /SunnnySummerConditions/
        public ActionResult SunnnySummerConditions()
        {
            ViewBag.BackLink = "SunnySummer";
            return View();
        }

        //
        //GET: /FallWinterConditions/
        public ActionResult FallWinterConditions()
        {
            ViewBag.BackLink = "FallWinter";
            return View();
        }

        //
        //GET: /UniversymConditions
        public ActionResult UniversalityConditions()
        {
            ViewBag.BackList = "Universality";
            return View();
        }

        //
        //GET: /GamesConditions
        public ActionResult GamesConditions()
        {
            ViewBag.BackList = "Games";
            return View();
        }

        //
        //GET: /Kolesa/Conditions/
        public ActionResult KolesaConditions()
        {
            ViewBag.BackLink = "Kolesa";
            return View();
        }

        //
        // GET: /Register/
        [Authorize (Users = "Andrey Andreev")]
        public ActionResult Index(string name, string date)
        {
            var request = db.Requests.ToList();
            if (name == "*") request = db.Requests.ToList();
            else
            {
                if (!string.IsNullOrEmpty(name)) request = db.Requests.Where(d => d.AppName.Contains(name)).ToList();
                else
                {
                    if (date != null)
                    {
                        var filterDate = Convert.ToDateTime(date);
                        request = db.Requests.Where(d => d.RegisterDate >= filterDate).ToList();
                    }
                }
            }
            return View(request);
        }

        //
        // GET: /Register/
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult IndexKolesa(string name, string date)
        {
            var request = db.UploadRequests.ToList();
            
            return View(request);
        }

        //
        // GET: /Register/Details/5
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult Details(Guid id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // GET: /Register/Details/Kolesa/5
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult DetailsKolesa(Guid id)
        {
            UploadRequest request = db.UploadRequests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = id;
            return View(request);
        }

        //
        // GET: /Register/KolesaTechRequest
        public ActionResult KolesaTechRequest()
        {
            ViewBag.BackLink = "Kolesa";
            return View();
        }

        //
        // GET: /Register/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Register/Create
        [CaptchaMvc.Attributes.CaptchaVerify("Ошибка: антиспам проверка не пройдена.")]
        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Сообщение: Отлично! Проверка на антиспам пройдена!";
                //request.Id = Guid.NewGuid();
                request.RegisterDate = DateTime.Today;
                request.ApprovalDate = DateTime.Today;
                db.Requests.Add(request);
                db.SaveChanges();
                var request1 = db.Requests.FirstOrDefault(d => d.AppUrl == request.AppUrl);
                return RedirectToAction("Success", new {id = request1.Id});
            }
            TempData["ErrorMessage"] = "Ошибка: антиспам проверка не пройдена.";
            return View(request);
        }


        //
        // GET: /Register/CreateWP

        public ActionResult CreateWP()
        {
            return View();
        }

        //
        // POST: /Register/Create
        [CaptchaMvc.Attributes.CaptchaVerify("Ошибка: антиспам проверка не пройдена.")]
        [HttpPost]
        public ActionResult CreateWP(Request request)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Сообщение: Отлично! Проверка на антиспам пройдена!";
                //request.Id = Guid.NewGuid();
                request.RegisterDate = DateTime.Today;
                request.ApprovalDate = DateTime.Today;
                db.Requests.Add(request);
                db.SaveChanges();
                var request1 = db.Requests.FirstOrDefault(d => d.WPhoneAppUrl == request.WPhoneAppUrl);
                return RedirectToAction("Success", new { id = request1.Id });
            }
            TempData["ErrorMessage"] = "Ошибка: антиспам проверка не пройдена.";
            return View(request);
        }

        public ActionResult CreateKolesa()
        {
            return View();
        }

        //
        // POST: /Register/Create
        [CaptchaMvc.Attributes.CaptchaVerify("Ошибка: антиспам проверка не пройдена.")]
        [HttpPost]
        public ActionResult CreateKolesa(UploadRequest request)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Сообщение: Отлично! Проверка на антиспам пройдена!";
                request.RegisterDate = DateTime.Today;
                request.ApprovalDate = DateTime.Today;
                db.UploadRequests.Add(request);
                db.SaveChanges();
                var request1 = db.UploadRequests.FirstOrDefault(d => d.Id == request.Id);
                return RedirectToAction("SuccessRegistered", new { id = request1.Id });
            }
            TempData["ErrorMessage"] = "Ошибка: антиспам проверка не пройдена.";
            return View(request);
        }

        public ActionResult EditKolesa()
        {
            ViewBag.Message = "";
            return View();
        }

        // POST: //Register/EditKolesa/id
        [HttpPost]
        public ActionResult EditKolesa(string code)
        {
            try
            {
                var codeGuid = new Guid(code);
                var existence = db.UploadRequests.Count(d => d.Id == codeGuid);
                if (existence > 0)
                {
                    return RedirectToAction("FilesUpload", new { id = codeGuid });
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Введённый код некорректен. Попробуйте ещё раз.";
            }
            return View();
        }

        public ActionResult EditKolesaAdm(Guid id)
        {
            ViewBag.Message = "";
            return View(db.UploadRequests.Find(id));
        }

        // POST: //Register/EditKolesa/id
        [HttpPost]
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult EditKolesaAdm(UploadRequest request)
        {
            if (ModelState.IsValid)
            {
                var requestNew = db.UploadRequests.Find(request.Id);
                requestNew.ApprovalDate = DateTime.Now;
                requestNew.Approved = request.Approved;
                db.SaveChanges();
                return RedirectToAction("IndexKolesa");
            }
            return View(request);
        }


        // GET: /Reqister/FilesUpload/id

        public ActionResult FilesUpload(Guid id)
        {
            var request = db.UploadRequests.FirstOrDefault(d => d.Id == id);
            return View(request);
        }

        // POST: /REgister/FilesUpload/id
        [HttpPost]
        public ActionResult FilesUpload([Bind(Exclude = "FileW8,FileWp8")] UploadRequest model, HttpPostedFileBase FileW8, HttpPostedFileBase FileWp8)
        {
            //if (ModelState.IsValid)
            {
                if ((FileWp8 != null) && (FileW8 != null))
                {
                    model.FileW8MimeType = FileW8.ContentType;
                    model.FileW8 = new byte[FileW8.ContentLength];
                    model.FileWp8MimeType = FileWp8.ContentType;
                    model.FileWp8 = new byte[FileWp8.ContentLength];
                    FileW8.InputStream.Read(model.FileW8, 0, FileW8.ContentLength);
                    FileWp8.InputStream.Read(model.FileWp8, 0, FileWp8.ContentLength);

                    var currRequest = db.UploadRequests.FirstOrDefault(d => d.Id == model.Id);
                    currRequest.FileW8 = model.FileW8;
                    currRequest.FileW8MimeType = model.FileW8MimeType;
                    currRequest.FileWp8 = model.FileWp8;
                    currRequest.FileWp8MimeType = model.FileWp8MimeType;
                    db.SaveChanges();
                    return RedirectToAction("SuccessUpload", new { id = model.Id});       
                }

            }
            var request = db.UploadRequests.FirstOrDefault(d => d.Id == model.Id);
            return View(request);
        }

        //
        //GET: /Register/Success

        public ActionResult Success(Guid id)
        {
            var reguest = db.Requests.Find(id);
            ViewBag.BackLink = "FallWinter";
            return View(reguest);
        }

        //
        //GET: /Register/Success

        public ActionResult SuccessRegistered(Guid id)
        {
            var reguest = db.UploadRequests.Find(id);
            ViewBag.BackLinkEvent = "Kolesa";
            ViewBag.UploadLink = "FilesUpload";
            return View(reguest);
        }

        //
        //GET: /Register/SuccessUpload

        public ActionResult SuccessUpload(Guid id)
        {
            var reguest = db.UploadRequests.Find(id);
            ViewBag.BackLinkEvent = "Kolesa";
            return View(reguest);
        }

        //
        // GET: /Register/Edit/5
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult Edit(Guid id )
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Register/Edit/5

        [HttpPost]
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                request.ApprovalDate = DateTime.Now;
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        //
        // GET: /Register/Delete/5
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult Delete(Guid id )
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Register/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Register/Delete/5
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult DeleteKolesa(Guid id)
        {
            UploadRequest request = db.UploadRequests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Register/Delete/5

        [HttpPost, ActionName("DeleteKolesa")]
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult DeleteKolesaConfirmed(Guid id)
        {
            UploadRequest request = db.UploadRequests.Find(id);
            db.UploadRequests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("IndexKolesa");
        }

        [HttpPost, ActionName("W8Download")]
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult W8Download(FormCollection formCollection)
        {
            var id = new Guid(formCollection["id"]);
            UploadRequest request1 = db.UploadRequests.Find(id);
            if ((request1.FileW8 != null) && (request1.FileW8MimeType != null))
            {
                byte[] data = request1.FileW8;
                return File(data, request1.FileW8MimeType, request1.LastName + "_" + request1.FirstName + "_W8.zip");
            }
            else
            {
                return RedirectToAction("DetailsKolesa", new { id = request1.Id });
            }
        }

        [HttpPost, ActionName("WPDownload")]
        [Authorize(Users = "Andrey Andreev")]
        public ActionResult WPDownload(FormCollection formCollection)
        {
            var id = new Guid(formCollection["id"]);
            UploadRequest request1 = db.UploadRequests.Find(id);
            if ((request1.FileWp8 != null) && (request1.FileWp8MimeType != null))
            {
                byte[] data = request1.FileWp8;
                return File(data, request1.FileWp8MimeType, request1.LastName + "_" + request1.FirstName + "_WP.zip");
            }
            else
            {
                return RedirectToAction("DetailsKolesa", new { id = request1.Id});
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [AcceptVerbs("post")]
        public ActionResult Rate(FormCollection form)
        {
            var rate = Convert.ToInt32(form["Score"]);
            var id = Convert.ToInt32(form["RequestID"]);
            if (Request.Cookies["rating" + id] != null)
                return Content("false");
            Response.Cookies["rating" + id].Value = DateTime.Now.ToString();
            Response.Cookies["rating" + id].Expires = DateTime.Now.AddYears(1);
            RequestRating ar = IncrementArticleRating(rate, id);
            return Json(ar);
        }

        public RequestRating IncrementArticleRating(int rate, int id)
        {
            var article = db.Ratings.First(a => a.RequestID == id);
            article.Rating += rate;
            article.TotalRaters += 1;
            db.SaveChanges();
            var ar = new RequestRating()
            {
                RequestID = article.RequestID,
                Rating = article.Rating,
                TotalRaters = article.TotalRaters,
                AverageRating = Convert.ToDouble(article.Rating) / Convert.ToDouble(article.TotalRaters)
            };
            return ar;
        }
    }
}
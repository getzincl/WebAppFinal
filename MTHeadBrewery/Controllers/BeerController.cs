using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MTHeadBrewery.DAL;
using MTHeadBrewery.Models;

namespace MTHeadBrewery.Controllers
{
    public class BeerController : Controller
    {
        private BreweryContext db = new BreweryContext();

        // GET: Beer
        public ActionResult Index()
        {
            return View(db.Beers.ToList());
        }

        // GET: Beer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Include(s => s.Files).SingleOrDefault(s => s.ID == id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // GET: Beer/Create
        [Authorize(Users = "superadmin@gmail.com, admin@gmail.com, employee@gmail.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BeerName,ABV,BeerDescription,FirstBrewed")] Beer beer, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        beer.Files = new List<File> { avatar };
                    }
                    db.Beers.Add(beer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(beer);
        }

        // GET: Beer/Edit/5
        [Authorize (Users = "superadmin@gmail.com, admin@gmail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Include(s => s.Files).SingleOrDefault(s => s.ID == id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: Beer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var beerToUpdate = db.Beers.Find(id);
            if (TryUpdateModel(beerToUpdate, "",
               new string[] { "BeerName","ABV","BeerDescription","FirstBrewed" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (beerToUpdate.Files.Any(f => f.FileType == FileType.Avatar))
                        {
                            db.Files.Remove(beerToUpdate.Files.First(f => f.FileType == FileType.Avatar));
                        }
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        beerToUpdate.Files = new List<File> { avatar };
                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(beerToUpdate);
        }

        // GET: Beer/Delete/5
        [Authorize(Users = "superadmin@gmail.com, admin@gmail.com")]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: Beer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
              
                Beer beer = db.Beers.Find(id);

                var beerToUpdate = db.Beers.Find(id);
                db.Files.Remove(beerToUpdate.Files.First(f => f.FileType == FileType.Avatar));
                        
                db.Beers.Remove(beer);
                db.SaveChanges();
            }
            catch (DataException /* dex */)
            {
                //Log the error (Uncomment dex variable name and add al ine here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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

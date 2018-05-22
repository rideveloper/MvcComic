using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcComic.Models;
using MvcComic.Models.DAL;

namespace MvcComic.Controllers
{
    public class ComicBooksController : Controller
    {
        private ComicContext db = new ComicContext();

        // GET: /ComicBooks/
        public ActionResult Index()
        {
            var comicbooks = db.ComicBooks.Include(c => c.Series);
            return View(comicbooks.ToList());
        }

        // GET: /ComicBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBook comicbook = db.ComicBooks.Find(id);
            if (comicbook == null)
            {
                return HttpNotFound();
            }
            return View(comicbook);
        }

        // GET: /ComicBooks/Create
        public ActionResult Create()
        {
            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Title");
            return View();
        }

        // POST: /ComicBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,SeriesId,IssueNumber,Description,PublishedOn,AverageRating")] ComicBook comicbook)
        {
            if (ModelState.IsValid)
            {
                db.ComicBooks.Add(comicbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Title", comicbook.SeriesId);
            return View(comicbook);
        }

        // GET: /ComicBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBook comicbook = db.ComicBooks.Find(id);
            if (comicbook == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Title", comicbook.SeriesId);
            return View(comicbook);
        }

        // POST: /ComicBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,SeriesId,IssueNumber,Description,PublishedOn,AverageRating")] ComicBook comicbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comicbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeriesId = new SelectList(db.Series, "Id", "Title", comicbook.SeriesId);
            return View(comicbook);
        }

        // GET: /ComicBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBook comicbook = db.ComicBooks.Find(id);
            if (comicbook == null)
            {
                return HttpNotFound();
            }
            return View(comicbook);
        }

        // POST: /ComicBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComicBook comicbook = db.ComicBooks.Find(id);
            db.ComicBooks.Remove(comicbook);
            db.SaveChanges();
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

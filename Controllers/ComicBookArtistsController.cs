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
    public class ComicBookArtistsController : Controller
    {
        private ComicContext db = new ComicContext();

        // GET: /ComicBookArtists/
        public ActionResult Index()
        {
            var comicbookartists = db.ComicBookArtists.Include(c => c.Artist).Include(c => c.ComicBook).Include(c => c.Role);
            return View(comicbookartists.ToList());
        }

        // GET: /ComicBookArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBookArtist comicbookartist = db.ComicBookArtists.Find(id);
            if (comicbookartist == null)
            {
                return HttpNotFound();
            }
            return View(comicbookartist);
        }

        // GET: /ComicBookArtists/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name");
            ViewBag.ComicBookId = new SelectList(db.ComicBooks, "Id", "Description");
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        // POST: /ComicBookArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ComicBookId,ArtistId,RoleId")] ComicBookArtist comicbookartist)
        {
            if (ModelState.IsValid)
            {
                db.ComicBookArtists.Add(comicbookartist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", comicbookartist.ArtistId);
            ViewBag.ComicBookId = new SelectList(db.ComicBooks, "Id", "Description", comicbookartist.ComicBookId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", comicbookartist.RoleId);
            return View(comicbookartist);
        }

        // GET: /ComicBookArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBookArtist comicbookartist = db.ComicBookArtists.Find(id);
            if (comicbookartist == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", comicbookartist.ArtistId);
            ViewBag.ComicBookId = new SelectList(db.ComicBooks, "Id", "Description", comicbookartist.ComicBookId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", comicbookartist.RoleId);
            return View(comicbookartist);
        }

        // POST: /ComicBookArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ComicBookId,ArtistId,RoleId")] ComicBookArtist comicbookartist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comicbookartist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", comicbookartist.ArtistId);
            ViewBag.ComicBookId = new SelectList(db.ComicBooks, "Id", "Description", comicbookartist.ComicBookId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", comicbookartist.RoleId);
            return View(comicbookartist);
        }

        // GET: /ComicBookArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBookArtist comicbookartist = db.ComicBookArtists.Find(id);
            if (comicbookartist == null)
            {
                return HttpNotFound();
            }
            return View(comicbookartist);
        }

        // POST: /ComicBookArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComicBookArtist comicbookartist = db.ComicBookArtists.Find(id);
            db.ComicBookArtists.Remove(comicbookartist);
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

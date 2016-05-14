using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class TitlesController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: /Titles (works) this is the default method that is called when we put in the url for Titles
        public ActionResult Index(string copySearch,string searchString)
        {          

            //query is defined but hasn't been run through the database
            var titles = from t in db.Titles
                         select t;

            //This is the command that searches for all the titles with the user's query
            if (!string.IsNullOrEmpty(searchString)) {
                titles = titles.Where(s => s.Title.Contains(searchString));
            }

            return View(titles); //returns the title list
        }//end Index()

        // GET: Titles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titles titles = db.Titles.Find(id);
            if (titles == null)
            {
                return HttpNotFound();
            }
            return View(titles);
        }

        // GET: Titles/Create (returns the form to Create)
        public ActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create (works)
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,Title,EditionNumber,Copyright,Subject")] Titles titles)
        {
            if (ModelState.IsValid)
            {
                    db.Entry(titles).State = EntityState.Added;
                    db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(titles);
        }//end Create

        // GET: Titles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titles titles = db.Titles.Find(id);
            if (titles == null)
            {
                return HttpNotFound();
            }
            return View(titles);
        }//end Edit

        // POST: Titles/Edit/{id} (id in this case, I think is ISBN) (works)
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,Title,EditionNumber,Copyright,Subject")] Titles titles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titles);
        }

        // GET: Titles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Titles titles = db.Titles.Find(id);

            if (titles == null)
            {
                return HttpNotFound();
            }
            return View(titles);
        }

        // POST: Titles/Delete/5 (works)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
                Titles titles = db.Titles.Find(id);
                db.Entry(titles).State = EntityState.Deleted;
                db.SaveChanges();
            return RedirectToAction("Index");
        }//end DeleteConfirmed

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }//end Dispose
    }
}

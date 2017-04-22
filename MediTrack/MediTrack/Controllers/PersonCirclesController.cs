using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediTrack.Entity;

namespace MediTrack.Controllers
{
    public class PersonCirclesController : Controller
    {
        private MedicDBEntities db = new MedicDBEntities();

        // GET: PersonCircles
        public ActionResult Index()
        {
            var personCircles = db.PersonCircles.Include(p => p.Circle).Include(p => p.Person);
            return View(personCircles.ToList());
        }

        // GET: PersonCircles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonCircle personCircle = db.PersonCircles.Find(id);
            if (personCircle == null)
            {
                return HttpNotFound();
            }
            return View(personCircle);
        }

        // GET: PersonCircles/Create
        public ActionResult Create()
        {
            ViewBag.CircleID = new SelectList(db.Circles, "ID", "CircleName");
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName");
            return View();
        }

        // POST: PersonCircles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PersonID,CircleID")] PersonCircle personCircle)
        {
            if (ModelState.IsValid)
            {
                db.PersonCircles.Add(personCircle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CircleID = new SelectList(db.Circles, "ID", "CircleName", personCircle.CircleID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", personCircle.PersonID);
            return View(personCircle);
        }

        // GET: PersonCircles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonCircle personCircle = db.PersonCircles.Find(id);
            if (personCircle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CircleID = new SelectList(db.Circles, "ID", "CircleName", personCircle.CircleID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", personCircle.PersonID);
            return View(personCircle);
        }

        // POST: PersonCircles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PersonID,CircleID")] PersonCircle personCircle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personCircle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CircleID = new SelectList(db.Circles, "ID", "CircleName", personCircle.CircleID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", personCircle.PersonID);
            return View(personCircle);
        }

        // GET: PersonCircles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonCircle personCircle = db.PersonCircles.Find(id);
            if (personCircle == null)
            {
                return HttpNotFound();
            }
            return View(personCircle);
        }

        // POST: PersonCircles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonCircle personCircle = db.PersonCircles.Find(id);
            db.PersonCircles.Remove(personCircle);
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

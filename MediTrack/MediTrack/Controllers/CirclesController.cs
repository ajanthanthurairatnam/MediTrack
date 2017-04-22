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
    public class CirclesController : Controller
    {
        private MedicDBEntities db = new MedicDBEntities();

        // GET: Circles
        public ActionResult Index()
        {
            return View(db.Circles.ToList());
        }

        // GET: Circles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circle circle = db.Circles.Find(id);
            if (circle == null)
            {
                return HttpNotFound();
            }
            return View(circle);
        }

        // GET: Circles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Circles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CircleName,CircleDescription")] Circle circle)
        {
            if (ModelState.IsValid)
            {
                db.Circles.Add(circle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(circle);
        }

        // GET: Circles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circle circle = db.Circles.Find(id);
            if (circle == null)
            {
                return HttpNotFound();
            }
            return View(circle);
        }

        // POST: Circles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CircleName,CircleDescription")] Circle circle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(circle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(circle);
        }

        // GET: Circles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circle circle = db.Circles.Find(id);
            if (circle == null)
            {
                return HttpNotFound();
            }
            return View(circle);
        }

        // POST: Circles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circle circle = db.Circles.Find(id);
            db.Circles.Remove(circle);
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

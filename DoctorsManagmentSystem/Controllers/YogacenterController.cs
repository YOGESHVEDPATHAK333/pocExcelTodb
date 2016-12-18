using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorsManagmentSystem.Models;

namespace DoctorsManagmentSystem.Controllers
{
    public class YogacenterController : Controller
    {
        private DoctorsManagementSystemEntities db = new DoctorsManagementSystemEntities();

        // GET: /Yogacenter/
        public ActionResult Index()
        {
            return View(db.Yogacenters.ToList());
        }

        // GET: /Yogacenter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yogacenter yogacenter = db.Yogacenters.Find(id);
            if (yogacenter == null)
            {
                return HttpNotFound();
            }
            return View(yogacenter);
        }

        // GET: /Yogacenter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Yogacenter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProcessingNumberId,FullName,DateOfBirth,Gender,Nationality,State,City,PermanantAddress,PinCode,PhoneNumber,Date,Email,AcademicQualification,Course,HealthStatus")] Yogacenter yogacenter)
        {
            if (ModelState.IsValid)
            {
                db.Yogacenters.Add(yogacenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yogacenter);
        }

        // GET: /Yogacenter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yogacenter yogacenter = db.Yogacenters.Find(id);
            if (yogacenter == null)
            {
                return HttpNotFound();
            }
            return View(yogacenter);
        }

        // POST: /Yogacenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProcessingNumberId,FullName,DateOfBirth,Gender,Nationality,State,City,PermanantAddress,PinCode,PhoneNumber,Date,Email,AcademicQualification,Course,HealthStatus")] Yogacenter yogacenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yogacenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yogacenter);
        }

        // GET: /Yogacenter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yogacenter yogacenter = db.Yogacenters.Find(id);
            if (yogacenter == null)
            {
                return HttpNotFound();
            }
            return View(yogacenter);
        }

        // POST: /Yogacenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yogacenter yogacenter = db.Yogacenters.Find(id);
            db.Yogacenters.Remove(yogacenter);
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

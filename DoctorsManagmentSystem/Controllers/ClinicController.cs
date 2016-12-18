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
    public class ClinicController : Controller
    {
        private DoctorsManagementSystemEntities db = new DoctorsManagementSystemEntities();

        // GET: /Clinic/
        public ActionResult Index()
        {
            var clinics = db.Clinics.Include(c => c.Doctor);
            return View(clinics.ToList());
        }

        // GET: /Clinic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // GET: /Clinic/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Title");
            return View();
        }

        // POST: /Clinic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DoctorId,ClinicName,Address,City,State,PinCode,Latitude,Longitude,ReceptionistAvaliable,LoginNeededForReceptionist,ReceptionistLoginMobileNumber,LandlineNumberOrMobileNumber,EmailId,MorningStartTime,MorningEndTime,EveningStartTime,EveningEndTime,Holidays,ScheduleDeatils,AppointmentMode,AppointmentSlotTime,AdditionalServicesInClinic,Fees,FollowUp")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                db.Clinics.Add(clinic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Title", clinic.DoctorId);
            return View(clinic);
        }

        // GET: /Clinic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Title", clinic.DoctorId);
            return View(clinic);
        }

        // POST: /Clinic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DoctorId,ClinicName,Address,City,State,PinCode,Latitude,Longitude,ReceptionistAvaliable,LoginNeededForReceptionist,ReceptionistLoginMobileNumber,LandlineNumberOrMobileNumber,EmailId,MorningStartTime,MorningEndTime,EveningStartTime,EveningEndTime,Holidays,ScheduleDeatils,AppointmentMode,AppointmentSlotTime,AdditionalServicesInClinic,Fees,FollowUp")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Title", clinic.DoctorId);
            return View(clinic);
        }

        // GET: /Clinic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: /Clinic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinic clinic = db.Clinics.Find(id);
            db.Clinics.Remove(clinic);
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

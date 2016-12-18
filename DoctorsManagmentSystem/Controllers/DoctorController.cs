using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DoctorsManagmentSystem.Models;
using LinqToExcel;

namespace DoctorsManagmentSystem.Controllers
{
    public class DoctorController : Controller
    {
        private DoctorsManagementSystemEntities db = new DoctorsManagementSystemEntities(); 

        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        } 

        public FileResult DownloadExcel()
        {
            string path = "/Doc/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }
         
        [HttpPost]
        public ActionResult UploadExcel(Doctor users, HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");  
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {


                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/Doc/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();

                    adapter.Fill(ds, "ExcelTable");

                    DataTable dtable = ds.Tables["ExcelTable"];

                    string sheetName = "Sheet1";

                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<Doctor>(sheetName) select a;

                    foreach (var a in artistAlbums)
                    {
                        try
                        {

                            Doctor TU = new Doctor();
                            TU.DoctorId = a.DoctorId;
                            TU.FormNumber = a.FormNumber;
                            TU.Date = a.Date;
                            TU.Title = a.Title;
                            TU.FullName = a.FullName;
                            TU.Gender = a.Gender;
                            TU.DateOfBirth = a.DateOfBirth;
                            TU.MobileNumber = a.MobileNumber;
                            TU.LandLineNumber = a.LandLineNumber;
                            TU.Qualifications = TU.Qualifications;
                            TU.Speciality = TU.Speciality;
                            TU.Expertise = TU.Expertise;
                            TU.RegistrationNumber = TU.RegistrationNumber;
                            TU.YearsOfExperience = TU.YearsOfExperience;
                            TU.ShortProfile = TU.ShortProfile;
                            TU.Email = TU.Email;
                            TU.Website = TU.Website;
                            TU.Subscription = TU.Subscription;
                            TU.SmartPhone = TU.SmartPhone;
                            db.Doctors.Add(TU);
                            db.SaveChanges();

                        }

                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {

                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {

                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);

                                }

                            }
                        }
                    }
                    //deleting excel file from folder  
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //alert message for invalid file format  
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            return View(db.Doctors.ToList());
        }



        // GET: /Doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: /Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,FormNumber,Date,Title,FullName,Gender,DateOfBirth,MobileNumber,LandLineNumber,Qualifications,Speciality,Expertise,RegistrationNumber,YearsOfExperience,ShortProfile,Email,Website,Subscription,SmartPhone")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: /Doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: /Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,FormNumber,Date,Title,FullName,Gender,DateOfBirth,MobileNumber,LandLineNumber,Qualifications,Speciality,Expertise,RegistrationNumber,YearsOfExperience,ShortProfile,Email,Website,Subscription,SmartPhone")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: /Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: /Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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

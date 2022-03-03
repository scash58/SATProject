using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.UI.MVC.Utilities;
using SATProject.DATA.EF;


namespace SATProject.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin, Scheduler")]
    public class StudentsController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.StudentStatus);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoUrl,SSID")] Student student, HttpPostedFileBase photoUrl)
        {
            if (ModelState.IsValid)
            {
                string file = "NoImage.png";
                if (photoUrl != null)
                {
                    file = photoUrl.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };
                    if (goodExts.Contains(ext.ToLower()) && photoUrl.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;
                        string savePath = Server.MapPath("~/Content/StudentImages/");
                        Image convertedImage = Image.FromStream(photoUrl.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                    }

                }
                student.PhotoUrl = file;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,SSID,PhotoUrl")] Student student, HttpPostedFileBase photoUrl)
        {
            if (ModelState.IsValid)
            {
                if (photoUrl != null)
                {
                    string file = photoUrl.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };
                    if (goodExts.Contains(ext.ToLower()) && photoUrl.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;
                        string savePath = Server.MapPath("~/Content/StudentImages/");
                        Image convertedImage = Image.FromStream(photoUrl.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        if (student.PhotoUrl != null && student.PhotoUrl != "NoImage.png")
                        {
                            string path = Server.MapPath("~/Content/StudentImages/");
                            ImageUtility.Delete(path, student.PhotoUrl);
                        }

                        student.PhotoUrl = file;
                    }

                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            //var activeStudentClasses = from stu in db.Students
            //                           join enr in db.Enrollments on stu.StudentId equals enr.StudentId
            //                           join shc in db.ScheduledClasses on enr.ScheduledClassId equals shc.ScheduledClassId
            //                           join cor in db.Courses on shc.CourseId equals cor.CourseId
            //                           where cor.IsActive == true
            //                           group stu by stu.StudentId;

            //ViewBag.ActiveStudentClasses = activeStudentClasses;                 

            return View(student);
        }

        // POST: Students/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            if (student.SSID == 2)
            {
                student.SSID = 3;
            }
            else
            {
                student.SSID = 2;
            }

            //string path = Server.MapPath("/Content/StudentImages/");
            //ImageUtility.Delete(path, student.PhotoUrl);
            //db.Students.Remove(student);
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

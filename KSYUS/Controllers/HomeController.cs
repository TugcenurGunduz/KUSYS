using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSYUS.Models;
namespace KSYUS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult index()
        {
           using(kusysEntities4 db=new kusysEntities4())
            {
                return View(db.students.ToList());
            }
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(students data)
        {
            kusysEntities4 db = new kusysEntities4();

            db.students.Add(data);
            db.SaveChanges();
            ViewBag.Bilgi = "Kayıt Başarılıdır.";
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(students data)
        {
            kusysEntities4 db = new kusysEntities4();

            db.students.Add(data);
            db.SaveChanges();
            ViewBag.Bilgi = "Kayıt Başarılıdır.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
           using(kusysEntities4 db=new kusysEntities4())
            {
                return View(db.students.Where(x => x.ID == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (kusysEntities4 db=new kusysEntities4())
                {
                    students students = db.students.Where(x => x.ID == id).FirstOrDefault();
                    db.students.Remove(students);
                    db.SaveChanges();
                }
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using(kusysEntities4 db = new kusysEntities4())
            {
                var model = db.students.Find(id);
                
                return View(model);
            }
           
        }
        [HttpPost]
        public ActionResult Edit(int? id, students students)
        {
            try
            {
                using(kusysEntities4 db=new kusysEntities4())
                {
                    db.Entry(students).State = EntityState.Modified;
                    db.SaveChanges();
                    
                }
                
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            kusysEntities4 db = new kusysEntities4();
            var model = db.students.Find(id);
            return View(model);
        }

        public ActionResult Lessons()
        {
            using (kusysEntities4 db = new kusysEntities4())
            {
                return View(db.course.ToList());
            }
        }

        [HttpGet]
        public ActionResult assign()
        {
            kusysEntities4 db = new kusysEntities4();
            List<SelectListItem> degerler = (from i in db.course.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CourseID,
                                                 Value = i.ID.ToString()
                                             }).ToList();

            List<SelectListItem> kisiler = (from i in db.students.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.FirstName,
                                                Value = i.ID.ToString()
                                            }).ToList();

            kursmodel mode = new kursmodel();
            
            ViewBag.std = kisiler;
            ViewBag.dgr = degerler;
            
            return View(mode);

            //using (kusysEntities4 db = new kusysEntities4())
            //{
            //    return View(db.students.ToList());
            //}
        }

      

            [HttpPost]
        public ActionResult Assignforstudents(students data)
        {
            kusysEntities4 db = new kusysEntities4();
            db.students.Add(data);
            db.SaveChanges();
            ViewBag.Bilgi = "Ders Atanmıştır.";
            return View();
        }

 
        [HttpGet]
        public ActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLesson(course data)
        {
            kusysEntities4 db = new kusysEntities4();

            db.course.Add(data);
            db.SaveChanges();
            ViewBag.Bilgi = "Kayıt Başarılıdır.";
            return View();
        }
    }
}
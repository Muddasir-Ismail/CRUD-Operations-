using CRUD_Operations_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations_.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid) 
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Insertd!!')</script>";
                    //TempData["InsertMessage"] = "<script>alert('Data Insertd!!')</script>";
                    TempData["InsertMessage"] = "Data Inserted!!";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data not Insertd!!')</script>";
                }
            }
            
            return View();
        }
        public ActionResult Edit(int Id)
        {
            var row = db.Students.Where(model => model.Id == Id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Data updated!!')</script>";
                    //ModelState.Clear();
                    TempData["UpdateMessage"] = "Data Updated!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data not updated!!')</script>";
                }
            }
            return View();
        }
    }
}
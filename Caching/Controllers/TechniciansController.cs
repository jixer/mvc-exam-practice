using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chris.Samples.MvcExam.Caching.Models;

namespace Chris.Samples.MvcExam.Caching.Controllers
{   
    public class TechniciansController : Controller
    {
        private CodeFirstContext context = new CodeFirstContext();

        //
        // GET: /Technicians/
        [OutputCache(Duration = 15)]
        public ViewResult Index()
        {
            return View(context.Technicians.ToList());
        }

        //
        // GET: /Technicians/Details/5

        public ViewResult Details(int id)
        {
            Technician technician = context.Technicians.Single(x => x.Id == id);
            return View(technician);
        }

        //
        // GET: /Technicians/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Technicians/Create

        [HttpPost]
        public ActionResult Create(Technician technician)
        {
            if (ModelState.IsValid)
            {
                context.Technicians.Add(technician);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(technician);
        }
        
        //
        // GET: /Technicians/Edit/5
 
        public ActionResult Edit(int id)
        {
            Technician technician = context.Technicians.Single(x => x.Id == id);
            return View(technician);
        }

        //
        // POST: /Technicians/Edit/5

        [HttpPost]
        public ActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                context.Entry(technician).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technician);
        }

        //
        // GET: /Technicians/Delete/5
 
        public ActionResult Delete(int id)
        {
            Technician technician = context.Technicians.Single(x => x.Id == id);
            return View(technician);
        }

        //
        // POST: /Technicians/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Technician technician = context.Technicians.Single(x => x.Id == id);
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
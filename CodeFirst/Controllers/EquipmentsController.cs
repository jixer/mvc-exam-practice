using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chris.Samples.MvcExam.CodeFirst.Models;

namespace Chris.Samples.MvcExam.CodeFirst.Controllers
{   
    public class EquipmentsController : Controller
    {
        private CodeFirstContext context = new CodeFirstContext();

        //
        // GET: /Equipments/

        public ViewResult Index()
        {
            return View(context.Equipments.ToList());
        }

        //
        // GET: /Equipments/Details/5

        public ViewResult Details(int id)
        {
            Equipment equipment = context.Equipments.Single(x => x.Id == id);
            return View(equipment);
        }

        //
        // GET: /Equipments/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Equipments/Create

        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                context.Equipments.Add(equipment);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(equipment);
        }
        
        //
        // GET: /Equipments/Edit/5
 
        public ActionResult Edit(int id)
        {
            Equipment equipment = context.Equipments.Single(x => x.Id == id);
            return View(equipment);
        }

        //
        // POST: /Equipments/Edit/5

        [HttpPost]
        public ActionResult Edit(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                context.Entry(equipment).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipment);
        }

        //
        // GET: /Equipments/Delete/5
 
        public ActionResult Delete(int id)
        {
            Equipment equipment = context.Equipments.Single(x => x.Id == id);
            return View(equipment);
        }

        //
        // POST: /Equipments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = context.Equipments.Single(x => x.Id == id);
            context.Equipments.Remove(equipment);
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
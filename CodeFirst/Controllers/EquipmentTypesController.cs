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
    public class EquipmentTypesController : Controller
    {
        private CodeFirstContext context = new CodeFirstContext();

        //
        // GET: /EquipmentTypes/

        public ViewResult Index()
        {
            return View(context.EquipmentTypes.ToList());
        }

        //
        // GET: /EquipmentTypes/Details/5

        public ViewResult Details(int id)
        {
            EquipmentType equipmenttype = context.EquipmentTypes.Single(x => x.Id == id);
            return View(equipmenttype);
        }

        //
        // GET: /EquipmentTypes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EquipmentTypes/Create

        [HttpPost]
        public ActionResult Create(EquipmentType equipmenttype)
        {
            if (ModelState.IsValid)
            {
                context.EquipmentTypes.Add(equipmenttype);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(equipmenttype);
        }
        
        //
        // GET: /EquipmentTypes/Edit/5
 
        public ActionResult Edit(int id)
        {
            EquipmentType equipmenttype = context.EquipmentTypes.Single(x => x.Id == id);
            return View(equipmenttype);
        }

        //
        // POST: /EquipmentTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(EquipmentType equipmenttype)
        {
            if (ModelState.IsValid)
            {
                context.Entry(equipmenttype).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipmenttype);
        }

        //
        // GET: /EquipmentTypes/Delete/5
 
        public ActionResult Delete(int id)
        {
            EquipmentType equipmenttype = context.EquipmentTypes.Single(x => x.Id == id);
            return View(equipmenttype);
        }

        //
        // POST: /EquipmentTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentType equipmenttype = context.EquipmentTypes.Single(x => x.Id == id);
            context.EquipmentTypes.Remove(equipmenttype);
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
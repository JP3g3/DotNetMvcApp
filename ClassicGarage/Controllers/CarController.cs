using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassicGarage.DAL;
using ClassicGarage.Models;

namespace ClassicGarage.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Car
        public ActionResult Index()
        {
            var car = db.Car.Include(c => c.Owner);
            return View(car.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName");
            return View();
        }

        // POST: Car/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mark,Model,Year,Name,VIN,Photo,DateOfPurchase,SaleDate,PurchasePrice,SalePrice,OwnerID")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                db.Car.Add(carModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }

        // POST: Car/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mark,Model,Year,Name,VIN,Photo,DateOfPurchase,SaleDate,PurchasePrice,SalePrice,OwnerID")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModels carModels = db.Car.Find(id);
            db.Car.Remove(carModels);
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

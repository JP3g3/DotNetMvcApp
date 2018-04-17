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
    public class PartsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Parts
        public ActionResult Index()
        {
            var part = db.Part.Include(p => p.Car);
            return View(part.ToList());
        }

        // GET: Parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.Part.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark");
            return View();
        }

        // POST: Parts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarID,Name,CatalogNmuber,DateOfPurchase,SaleDate,PurchasePrice,SalePrice")] PartsModels partsModels)
        {
            if (ModelState.IsValid)
            {
                db.Part.Add(partsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark", partsModels.CarID);
            return View(partsModels);
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.Part.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark", partsModels.CarID);
            return View(partsModels);
        }

        // POST: Parts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarID,Name,CatalogNmuber,DateOfPurchase,SaleDate,PurchasePrice,SalePrice")] PartsModels partsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark", partsModels.CarID);
            return View(partsModels);
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.Part.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartsModels partsModels = db.Part.Find(id);
            db.Part.Remove(partsModels);
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

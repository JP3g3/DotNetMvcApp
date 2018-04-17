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
    public class AnnouncementsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Announcements
        public ActionResult Index()
        {
            var announcements = db.Announcements.Include(a => a.Car);
            return View(announcements.ToList());
        }

        // GET: Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementsModels announcementsModels = db.Announcements.Find(id);
            if (announcementsModels == null)
            {
                return HttpNotFound();
            }
            return View(announcementsModels);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark");
            return View();
        }

        // POST: Announcements/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarID,Activ")] AnnouncementsModels announcementsModels)
        {
            if (ModelState.IsValid)
            {
                db.Announcements.Add(announcementsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark", announcementsModels.CarID);
            return View(announcementsModels);
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementsModels announcementsModels = db.Announcements.Find(id);
            if (announcementsModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark", announcementsModels.CarID);
            return View(announcementsModels);
        }

        // POST: Announcements/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarID,Activ")] AnnouncementsModels announcementsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcementsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Mark", announcementsModels.CarID);
            return View(announcementsModels);
        }

        // GET: Announcements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnouncementsModels announcementsModels = db.Announcements.Find(id);
            if (announcementsModels == null)
            {
                return HttpNotFound();
            }
            return View(announcementsModels);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnnouncementsModels announcementsModels = db.Announcements.Find(id);
            db.Announcements.Remove(announcementsModels);
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

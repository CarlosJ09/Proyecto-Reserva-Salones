using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using P_ReservaSalon;

namespace P_ReservaSalon.Controllers
{
    public class SalonsController : Controller
    {
        private Entities db = new Entities();

        // GET: Salons
        public ActionResult Index()
        {
            var salon = db.Salon.Include(s => s.TipoSalon);
            return View(salon.ToList());
        }

        // GET: Salons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salon.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // GET: Salons/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoSalon = new SelectList(db.TipoSalon, "Id", "SalonTipo");
            return View();
        }

        // POST: Salons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,IdTipoSalon,Ubicacion,Disponible")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Salon.Add(salon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoSalon = new SelectList(db.TipoSalon, "Id", "SalonTipo", salon.IdTipoSalon);
            return View(salon);
        }

        // GET: Salons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salon.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoSalon = new SelectList(db.TipoSalon, "Id", "SalonTipo", salon.IdTipoSalon);
            return View(salon);
        }

        // POST: Salons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,IdTipoSalon,Ubicacion,Disponible")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoSalon = new SelectList(db.TipoSalon, "Id", "SalonTipo", salon.IdTipoSalon);
            return View(salon);
        }

        // GET: Salons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salon.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: Salons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salon salon = db.Salon.Find(id);
            db.Salon.Remove(salon);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reserva_Salones;

namespace Reserva_Salones.Controllers
{
    public class SalonesController : Controller
    {
        private Entities db = new Entities();

        // GET: Salones
        public ActionResult Index()
        {
            var salons = db.Salons.Include(s => s.TipoSalon);
            return View(salons.ToList());
        }

        // GET: Salones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // GET: Salones/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo");
            return View();
        }

        // POST: Salones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imagen,Nombre,IdTipoSalon,Ubicacion,Disponible")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Salons.Add(salon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo", salon.IdTipoSalon);
            return View(salon);
        }

        // GET: Salones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo", salon.IdTipoSalon);
            return View(salon);
        }

        // POST: Salones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imagen,Nombre,IdTipoSalon,Ubicacion,Disponible")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo", salon.IdTipoSalon);
            return View(salon);
        }

        // GET: Salones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: Salones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salon salon = db.Salons.Find(id);
            db.Salons.Remove(salon);
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

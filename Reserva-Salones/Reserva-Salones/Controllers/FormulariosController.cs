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
    public class FormulariosController : Controller
    {
        private Entities db = new Entities();

        // GET: Formularios
        public ActionResult Index()
        {
            var formularios = db.Formularios.Include(f => f.TipoSalon);
            return View(formularios.ToList());
        }

        // GET: Formularios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return HttpNotFound();
            }
            return View(formulario);
        }

        // GET: Formularios/Create
        public ActionResult Create()
        {
            ViewBag.IdSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo");
            return View();
        }

        // POST: Formularios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombre,Telefono,Email,IdSalon,MaxPersonas,FechaReserva")] Formulario formulario)
        { 
            if (ModelState.IsValid)
            {
                formulario.FechaCreacion = DateTime.Now;
                db.Formularios.Add(formulario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo", formulario.IdSalon);
            return View(formulario);
        }

        // GET: Formularios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo", formulario.IdSalon);
            return View(formulario);
        }

        // POST: Formularios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombre,Telefono,Email,IdSalon,MaxPersonas,FechaReserva,FechaCreacion")] Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSalon = new SelectList(db.TipoSalons, "Id", "SalonTipo", formulario.IdSalon);
            return View(formulario);
        }

        // GET: Formularios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return HttpNotFound();
            }
            return View(formulario);
        }

        // POST: Formularios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Formulario formulario = db.Formularios.Find(id);
            db.Formularios.Remove(formulario);
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

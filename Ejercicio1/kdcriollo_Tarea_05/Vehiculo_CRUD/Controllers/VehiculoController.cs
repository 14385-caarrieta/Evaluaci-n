using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehiculo_CRUD.Models;

namespace CRUD_Vehiculos.Controllers
{
    public class VehiculoController : Controller
    {
        private VehiculoMatricula_BDEntities db = new VehiculoMatricula_BDEntities();
        // GET: Vehiculo
        public ActionResult Index()
        {
            VehiculoMatricula_BDEntities db = new VehiculoMatricula_BDEntities();

            return View(db.vehiculo.ToList());
        }



        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                int vehiculoId = int.Parse(id);
                var vehiculo = db.vehiculo.Find(vehiculoId);

                if (vehiculo != null)
                {
                    return View(vehiculo);
                }

                ModelState.AddModelError("", "No se encontró el vehículo especificado.");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al mostrar el detalle del vehículo: " + ex.Message);
                return View();
            }
        }

        public ActionResult Agregar()
        {
            ViewBag.color = new SelectList(db.color, "id", "descripcion");
            ViewBag.color = new SelectList(db.color, "id", "descripcion");
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion");
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion");
            return View();
        }

        // POST: vehiculo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar([Bind(Include = "id,placa,marca,motor,chasis,combustible,anio,color,foto,avaluo")] vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.color = new SelectList(db.color, "id", "descripcion", vehiculo.color);
            ViewBag.color = new SelectList(db.color, "id", "descripcion", vehiculo.color);
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion", vehiculo.marca);
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion", vehiculo.marca);
            return View(vehiculo);
        }

        // GET: vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.color = new SelectList(db.color, "id", "descripcion", vehiculo.color);
            ViewBag.color = new SelectList(db.color, "id", "descripcion", vehiculo.color);
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion", vehiculo.marca);
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion", vehiculo.marca);
            return View(vehiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,placa,marca,motor,chasis,combustible,anio,color,foto,avaluo")] vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.color = new SelectList(db.color, "id", "descripcion", vehiculo.color);
            ViewBag.color = new SelectList(db.color, "id", "descripcion", vehiculo.color);
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion", vehiculo.marca);
            ViewBag.marca = new SelectList(db.marca, "id", "descripcion", vehiculo.marca);
            return View(vehiculo);
        }

        // GET: vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehiculo vehiculo = db.vehiculo.Find(id);
            db.vehiculo.Remove(vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

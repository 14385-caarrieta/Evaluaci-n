﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehiculo_CRUD.Models;

namespace Vehiculo_CRUD.Controllers
{
    public class agenciasController : Controller
    {
        private VehiculoMatricula_BDEntities db = new VehiculoMatricula_BDEntities();

        // GET: agencias
        public ActionResult Index()
        {
            return View(db.agencia.ToList());
        }

        // GET: agencias/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agencia agencia = db.agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // GET: agencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: agencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,direccion,telefono,horainicio,horafin,foto")] agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.agencia.Add(agencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agencia);
        }

        // GET: agencias/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agencia agencia = db.agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: agencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,direccion,telefono,horainicio,horafin,foto")] agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agencia);
        }

        // GET: agencias/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agencia agencia = db.agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: agencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            agencia agencia = db.agencia.Find(id);
            db.agencia.Remove(agencia);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TietokantasovellusMvc.Models;

namespace TietokantasovellusMvc.Controllers
{
    public class ProjektiController : Controller
    {
        private HarjoitustietokantaEntities db = new HarjoitustietokantaEntities();

        // GET: Projekti
        public ActionResult Index()
        {
            HarjoitustietokantaEntities entities = new HarjoitustietokantaEntities();
            List<Projektit> model = entities.Projektit.ToList();
            entities.Dispose();

            return View(model);
        }

        // GET: Projekti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projektit projektit = db.Projektit.Find(id);
            if (projektit == null)
            {
                return HttpNotFound();
            }
            return View(projektit);
        }

        // GET: Projekti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projekti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjektiID,Nimi")] Projektit projektit)
        {
            if (ModelState.IsValid)
            {
                db.Projektit.Add(projektit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projektit);
        }

        // GET: Projekti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projektit projektit = db.Projektit.Find(id);
            if (projektit == null)
            {
                return HttpNotFound();
            }
            return View(projektit);
        }

        // POST: Projekti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjektiID,Nimi")] Projektit projektit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projektit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projektit);
        }

        // GET: Projekti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projektit projektit = db.Projektit.Find(id);
            if (projektit == null)
            {
                return HttpNotFound();
            }
            return View(projektit);
        }

        // POST: Projekti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projektit projektit = db.Projektit.Find(id);
            db.Projektit.Remove(projektit);
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

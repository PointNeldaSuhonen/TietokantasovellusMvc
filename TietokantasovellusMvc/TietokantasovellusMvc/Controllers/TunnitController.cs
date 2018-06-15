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
    public class TunnitController : Controller
    {
        private HarjoitustietokantaEntities db = new HarjoitustietokantaEntities();

        // GET: Tunnit
        public ActionResult Index()
        {
            HarjoitustietokantaEntities entities = new HarjoitustietokantaEntities();
            List<Tunnit> model = entities.Tunnit.ToList();
            entities.Dispose();

            return View(model);

            // return View(db.Tunnit.ToList());
        }

        // GET: Tunnit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tunnit tunnit = db.Tunnit.Find(id);
            if (tunnit == null)
            {
                return HttpNotFound();
            }
            return View(tunnit);
        }

        // GET: Tunnit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tunnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TuntiID,ProjektiID,HenkiloID,Pvm,Tunnit1")] Tunnit tunnit)
        {
            if (ModelState.IsValid)
            {
                db.Tunnit.Add(tunnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tunnit);
        }

        // GET: Tunnit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tunnit tunnit = db.Tunnit.Find(id);
            if (tunnit == null)
            {
                return HttpNotFound();
            }
            return View(tunnit);
        }

        // POST: Tunnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TuntiID,ProjektiID,HenkiloID,Pvm,Tunnit1")] Tunnit tunnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tunnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tunnit);
        }

        // GET: Tunnit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tunnit tunnit = db.Tunnit.Find(id);
            if (tunnit == null)
            {
                return HttpNotFound();
            }
            return View(tunnit);
        }

        // POST: Tunnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tunnit tunnit = db.Tunnit.Find(id);
            db.Tunnit.Remove(tunnit);
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

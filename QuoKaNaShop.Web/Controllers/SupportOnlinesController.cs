using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuoKaNaShop.Data;
using QuoKaNaShop.Model.Models;

namespace QuoKaNaShop.Web.Controllers
{
    public class SupportOnlinesController : Controller
    {
        private QuoKaNaDBContext db = new QuoKaNaDBContext();

        // GET: SupportOnlines
        public ActionResult Index()
        {
            return View(db.SupportOnlines.ToList());
        }

        // GET: SupportOnlines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportOnline supportOnline = db.SupportOnlines.Find(id);
            if (supportOnline == null)
            {
                return HttpNotFound();
            }
            return View(supportOnline);
        }

        // GET: SupportOnlines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupportOnlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Department,Skype,Mobile,Email,Yahoo,Facebook,Status,DisplayOrder")] SupportOnline supportOnline)
        {
            if (ModelState.IsValid)
            {
                db.SupportOnlines.Add(supportOnline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supportOnline);
        }

        // GET: SupportOnlines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportOnline supportOnline = db.SupportOnlines.Find(id);
            if (supportOnline == null)
            {
                return HttpNotFound();
            }
            return View(supportOnline);
        }

        // POST: SupportOnlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Department,Skype,Mobile,Email,Yahoo,Facebook,Status,DisplayOrder")] SupportOnline supportOnline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supportOnline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supportOnline);
        }

        // GET: SupportOnlines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportOnline supportOnline = db.SupportOnlines.Find(id);
            if (supportOnline == null)
            {
                return HttpNotFound();
            }
            return View(supportOnline);
        }

        // POST: SupportOnlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupportOnline supportOnline = db.SupportOnlines.Find(id);
            db.SupportOnlines.Remove(supportOnline);
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

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
    public class MenuGroupsController : Controller
    {
        private QuoKaNaDBContext db = new QuoKaNaDBContext();

        // GET: MenuGroups
        public ActionResult Index()
        {
            return View(db.MenuGroups.ToList());
        }

        // GET: MenuGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuGroup menuGroup = db.MenuGroups.Find(id);
            if (menuGroup == null)
            {
                return HttpNotFound();
            }
            return View(menuGroup);
        }

        // GET: MenuGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] MenuGroup menuGroup)
        {
            if (ModelState.IsValid)
            {
                db.MenuGroups.Add(menuGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuGroup);
        }

        // GET: MenuGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuGroup menuGroup = db.MenuGroups.Find(id);
            if (menuGroup == null)
            {
                return HttpNotFound();
            }
            return View(menuGroup);
        }

        // POST: MenuGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] MenuGroup menuGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuGroup);
        }

        // GET: MenuGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuGroup menuGroup = db.MenuGroups.Find(id);
            if (menuGroup == null)
            {
                return HttpNotFound();
            }
            return View(menuGroup);
        }

        // POST: MenuGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuGroup menuGroup = db.MenuGroups.Find(id);
            db.MenuGroups.Remove(menuGroup);
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

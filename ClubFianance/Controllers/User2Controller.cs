using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubFinance.Models;

namespace ClubFinance.Controllers
{
    public class User2Controller : Controller
    {
        private User2DbContext db = new User2DbContext();

        // GET: User2
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: User2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.Users.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // GET: User2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,ConfirmPassword,FirstName,LastName")] User2 user2)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user2);
        }

        // GET: User2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.Users.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // POST: User2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,ConfirmPassword,FirstName,LastName")] User2 user2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user2);
        }

        // GET: User2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.Users.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // POST: User2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User2 user2 = db.Users.Find(id);
            db.Users.Remove(user2);
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

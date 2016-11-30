using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubFinance.Models;

namespace ClubFinance.Content
{
    public class Club2Controller : Controller
    {
        private Club2DbContext db = new Club2DbContext();

        // GET: Club2
        public ActionResult Index(int? mode)
        {

            if (mode == null)
            {
                mode = 1;
            }
            ViewBag.mode = mode;    // mode = 1 (Admin Perspective)
                                    // mode = 2 (Officer Perspective)
                                    // mode = 3 (User Perspective)
            return View(db.Clubs.ToList());
        }

        // GET: Club2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club2 club2 = db.Clubs.Find(id);
            if (club2 == null)
            {
                return HttpNotFound();
            }
            return View(club2);
        }

        // GET: Club2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Club2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NickName")] Club2 club2)
        {
            if (ModelState.IsValid)
            {
                var id = Guid.NewGuid().GetHashCode();

                db.Clubs.Add(club2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(club2);
        }

        // GET: Club2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club2 club2 = db.Clubs.Find(id);
            if (club2 == null)
            {
                return HttpNotFound();
            }
            return View(club2);
        }

        // POST: Club2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NickName")] Club2 club2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(club2);
        }

        /*
        public ActionResult AddMembershipOption(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //return Redirect()
            return View("../MembershipOption2/Create", new { ClubId = id });
           
        }
        */

        // GET: Club2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club2 club2 = db.Clubs.Find(id);
            if (club2 == null)
            {
                return HttpNotFound();
            }
            return View(club2);
        }

        // POST: Club2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club2 club2 = db.Clubs.Find(id);
            db.Clubs.Remove(club2);
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

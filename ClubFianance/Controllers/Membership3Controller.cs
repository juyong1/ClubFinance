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
    public class Membership3Controller : Controller
    {
        private Membership3DbContext db = new Membership3DbContext();

        // GET: Membership3
        public ActionResult Index()
        {
            return View(db.Memberships.ToList());
        }

        // GET: Membership3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership3 membership3 = db.Memberships.Find(id);
            if (membership3 == null)
            {
                return HttpNotFound();
            }
            return View(membership3);
        }

        // GET: Membership3/Create
        public ActionResult Create(int? clubId, string clubName, string clubNickName, int? userId, string userFirstName, string userLastName)
        {
            if (clubId == null || userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ClubId = clubId;
            ViewBag.ClubName = clubName;
            ViewBag.ClubNickName = clubNickName;
            ViewBag.UserId = userId;
            ViewBag.UserFirstName = userFirstName;
            ViewBag.UserLastName = userLastName;
          
            MembershipOption2DbContext optionDb = new MembershipOption2DbContext();
            ViewBag.MembershipOptions = optionDb.MembershipOptions.Where(n => n.ClubId == clubId).ToList();

            return View();

        }

        // POST: Membership3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ClubId,Option,RegistrationDate,IsMember,UnregistrationDate")] Membership3 membership3)
        {
            
            if (ModelState.IsValid)
            {
                membership3.RegistrationDate = DateTime.Now;
                membership3.UnregistrationDate = DateTime.Now;

                db.Memberships.Add(membership3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membership3);
        }

        // GET: Membership3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership3 membership3 = db.Memberships.Find(id);
            if (membership3 == null)
            {
                return HttpNotFound();
            }
            return View(membership3);
        }

        // POST: Membership3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ClubId,MembershipOptionId,RegistrationDate,IsMember,UnregistrationDate")] Membership3 membership3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membership3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membership3);
        }

        // GET: Membership3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership3 membership3 = db.Memberships.Find(id);
            if (membership3 == null)
            {
                return HttpNotFound();
            }
            return View(membership3);
        }

        // POST: Membership3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membership3 membership3 = db.Memberships.Find(id);
            db.Memberships.Remove(membership3);
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

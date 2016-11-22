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
    public class MembershipOption2Controller : Controller
    {
        private MembershipOption2DbContext db = new MembershipOption2DbContext();

        // GET: MembershipOption2
        public ActionResult Index(int? clubId, string clubName, string clubNickName)
        {
            if (clubId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ClubId = clubId;
            ViewBag.ClubName = clubName;
            ViewBag.ClubNickName = clubNickName;

            return View(db.MembershipOptions.Where(n => n.ClubId == clubId).ToList());
        }

        // GET: MembershipOption2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipOption2 membershipOption2 = db.MembershipOptions.Find(id);
            if (membershipOption2 == null)
            {
                return HttpNotFound();
            }
            return View(membershipOption2);
        }

        // GET: MembershipOption2/Create
        public ActionResult Create(int? clubId, string clubName, string clubNickName)
        {

            if (clubId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ClubId = clubId;
            ViewBag.ClubName = clubName;
            ViewBag.ClubNickName = clubNickName;

            return View();
        }

        // POST: MembershipOption2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClubId,Option,OtherName,Expiration,Price,Description,IsActive")] MembershipOption2 membershipOption2)
        {
            if (ModelState.IsValid)
            {
                db.MembershipOptions.Add(membershipOption2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipOption2);
        }

        // GET: MembershipOption2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipOption2 membershipOption2 = db.MembershipOptions.Find(id);
            if (membershipOption2 == null)
            {
                return HttpNotFound();
            }
            return View(membershipOption2);
        }

        // POST: MembershipOption2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClubId,Option,OtherName,Expiration,Price,Description,IsActive")] MembershipOption2 membershipOption2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipOption2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipOption2);
        }

        // GET: MembershipOption2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipOption2 membershipOption2 = db.MembershipOptions.Find(id);
            if (membershipOption2 == null)
            {
                return HttpNotFound();
            }
            return View(membershipOption2);
        }

        // POST: MembershipOption2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembershipOption2 membershipOption2 = db.MembershipOptions.Find(id);
            db.MembershipOptions.Remove(membershipOption2);
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

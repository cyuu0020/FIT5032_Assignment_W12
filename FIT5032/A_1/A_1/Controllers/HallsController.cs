using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A_1.Models; 
using Microsoft.AspNet.Identity; 
using A_1.Controllers;



namespace A_1.Controllers
{
    [Authorize]
    public class HallsController : Controller
    {
        private A_1_Models db = new A_1_Models();

        // GET: Halls

        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Owner"))
            {
                var userId = User.Identity.GetUserId();
                var halls = db.Hall.Where(s => s.OwnerId == userId).ToList();

                return View(halls.ToList());
            }
            else
            {
                var hall = db.Hall.Include(h => h.AspNetUsers);
                return View(hall.ToList());
            }
        }

        // GET: Halls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: Halls/Create
        [Authorize(Roles = "Owner")]
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }


        // GET: Halls/Create
        [Authorize]
        public ActionResult Booking()
        {
            var ctrl = new BookingsController();

            return ctrl.Create();
        }


        // POST: Halls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Owner")]
        public ActionResult Create([Bind(Include = "Id,Description,HallName,fee,Address,openTime,closeTime,status,latitude,longitude")] Hall hall)
        {
            hall.OwnerId = User.Identity.GetUserId();
            hall.createDate = DateTime.Today;
            hall.rating = 3;
            ModelState.Clear();
            TryValidateModel(hall);

            if (ModelState.IsValid)
            {
                db.Hall.Add(hall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.AspNetUsers, "Id", "Email", hall.OwnerId);
            return View(hall);
        }

        // GET: Halls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.AspNetUsers, "Id", "Email", hall.OwnerId);
            return View(hall);
        }

        // POST: Halls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,OwnerId,Description,HallName,fee,Address,createDate,openTime,closeTime,status,rating,latitude,longitude")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.AspNetUsers, "Id", "Email", hall.OwnerId);
            return View(hall);
        }

        // GET: Halls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            Hall hall = db.Hall.Find(id);
            db.Hall.Remove(hall);
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

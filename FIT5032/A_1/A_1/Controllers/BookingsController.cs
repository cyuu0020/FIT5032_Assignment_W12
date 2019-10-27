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

namespace A_1.Controllers
{
    
    public class BookingsController : Controller
    {
        private A_1_Models db = new A_1_Models();

        // GET: Bookings
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Owner"))
            {
                var userId = User.Identity.GetUserId();
                var bookings = db.Booking.Where(s => s.Hall.OwnerId == userId).ToList();

                return View(bookings.ToList());
            }
            else if (User.IsInRole("Administrator"))
            {
                var booking = db.Booking.Include(b => b.AspNetUsers).Include(b => b.Hall);
                return View(booking.ToList());
            }
            else
            {
                var userId = User.Identity.GetUserId();
                var bookings = db.Booking.Where(s => s.CustomerId == userId).ToList();
                return View(bookings.ToList()); 
            }
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.hallId = new SelectList(db.Hall, "Id", "HallName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,BookingDate,hallId")] Booking booking)
        {
            booking.CustomerId = User.Identity.GetUserId();
            booking.createDate = DateTime.Today; 
            if (ModelState.IsValid)
            {
                db.Booking.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.AspNetUsers, "Id", "Email", booking.CustomerId);
            ViewBag.hallId = new SelectList(db.Hall, "Id", "OwnerId", booking.hallId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.AspNetUsers, "Id", "Email", booking.CustomerId);
            ViewBag.hallId = new SelectList(db.Hall, "Id", "OwnerId", booking.hallId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,BookingDate,BookingTime,hallId,fee,rating,comment,ratingDate,phone,createDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.AspNetUsers, "Id", "Email", booking.CustomerId);
            ViewBag.hallId = new SelectList(db.Hall, "Id", "OwnerId", booking.hallId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Booking.Find(id);
            db.Booking.Remove(booking);
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


        // GET: Bookings/Rating/5
        public ActionResult Rating(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.AspNetUsers, "Id", "Email", booking.CustomerId);
            ViewBag.hallId = new SelectList(db.Hall, "Id", "OwnerId", booking.hallId);
            return View(booking);
        }

        // POST: Bookings/Rating/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Rating([Bind(Include = "Id,CustomerId,BookingDate,BookingTime,hallId,fee,rating,comment,ratingDate,phone,createDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.AspNetUsers, "Id", "Email", booking.CustomerId);
            ViewBag.hallId = new SelectList(db.Hall, "Id", "OwnerId", booking.hallId);
            return View(booking);
        }

    }
}

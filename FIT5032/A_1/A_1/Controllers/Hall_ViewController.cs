using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A_1.Models;

namespace A_1.Controllers
{
    [Authorize]
    public class Hall_ViewController : Controller
    {
        private Hall_View_Models db = new Hall_View_Models();

        // GET: Hall_View
        public ActionResult Index()
        {
            return View(db.Hall_View.ToList());
        }

        // GET: Hall_View/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall_View hall_View = db.Hall_View.Find(id);
            if (hall_View == null)
            {
                return HttpNotFound();
            }
            return View(hall_View);
        }

        // GET: Hall_View/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hall_View/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,OwnerId,Description,HallName,fee,Address,createDate,openTime,closeTime,status,rating,latitude,longitude,rating1")] Hall_View hall_View)
        {
            if (ModelState.IsValid)
            {
                db.Hall_View.Add(hall_View);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hall_View);
        }

        // GET: Hall_View/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall_View hall_View = db.Hall_View.Find(id);
            if (hall_View == null)
            {
                return HttpNotFound();
            }
            return View(hall_View);
        }

        // POST: Hall_View/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,OwnerId,Description,HallName,fee,Address,createDate,openTime,closeTime,status,rating,latitude,longitude,rating1")] Hall_View hall_View)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hall_View).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hall_View);
        }

        // GET: Hall_View/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall_View hall_View = db.Hall_View.Find(id);
            if (hall_View == null)
            {
                return HttpNotFound();
            }
            return View(hall_View);
        }

        // POST: Hall_View/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hall_View hall_View = db.Hall_View.Find(id);
            db.Hall_View.Remove(hall_View);
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

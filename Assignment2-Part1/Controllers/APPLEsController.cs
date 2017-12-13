using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1_Apple.Models;

namespace Assignment1_Apple.Controllers
{
    
    public class APPLEsController : Controller
    {
        private AppleModel db = new AppleModel();

        // GET: APPLEs
        public ActionResult Index()
        {
            return View(db.APPLEs.ToList());
        }

        // GET: APPLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLE aPPLE = db.APPLEs.Find(id);
            if (aPPLE == null)
            {
                return HttpNotFound();
            }
            return View(aPPLE);
        }

        // GET: APPLEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APPLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCT_ID,LOCATION_CODE,ADDRESS,CITY,PROVINCE,COUNTRY,CUSTOMER_CARE,PRODUCTS")] APPLE aPPLE)
        {
            if (ModelState.IsValid)
            {
                db.APPLEs.Add(aPPLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aPPLE);
        }

        // GET: APPLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLE aPPLE = db.APPLEs.Find(id);
            if (aPPLE == null)
            {
                return HttpNotFound();
            }
            return View(aPPLE);
        }

        // POST: APPLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCT_ID,LOCATION_CODE,ADDRESS,CITY,PROVINCE,COUNTRY,CUSTOMER_CARE,PRODUCTS")] APPLE aPPLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPPLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aPPLE);
        }

        // GET: APPLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLE aPPLE = db.APPLEs.Find(id);
            if (aPPLE == null)
            {
                return HttpNotFound();
            }
            return View(aPPLE);
        }

        // POST: APPLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APPLE aPPLE = db.APPLEs.Find(id);
            db.APPLEs.Remove(aPPLE);
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

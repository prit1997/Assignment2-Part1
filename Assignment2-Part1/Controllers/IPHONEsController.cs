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
    [Authorize]
    public class IPHONEsController : Controller
    {
        private AppleModel db = new AppleModel();

        // GET: IPHONEs
        public ActionResult Index()
        {
            var iPHONEs = db.IPHONEs.Include(i => i.APPLE);
            return View(iPHONEs.ToList());
        }

        // GET: IPHONEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPHONE iPHONE = db.IPHONEs.Find(id);
            if (iPHONE == null)
            {
                return HttpNotFound();
            }
            return View(iPHONE);
        }

        // GET: IPHONEs/Create
        public ActionResult Create()
        {
            ViewBag.PRODUCT_ID = new SelectList(db.APPLEs, "PRODUCT_ID", "ADDRESS");
            return View();
        }

        // POST: IPHONEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SERIAL_NO,PRODUCT_ID,PRODUCT_NAME,PRODUCT_SERIES,PRODUCT_STORAGE,PRODUCT_PROCESSOR")] IPHONE iPHONE)
        {
            if (ModelState.IsValid)
            {
                db.IPHONEs.Add(iPHONE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRODUCT_ID = new SelectList(db.APPLEs, "PRODUCT_ID", "ADDRESS", iPHONE.PRODUCT_ID);
            return View(iPHONE);
        }

        // GET: IPHONEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPHONE iPHONE = db.IPHONEs.Find(id);
            if (iPHONE == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRODUCT_ID = new SelectList(db.APPLEs, "PRODUCT_ID", "ADDRESS", iPHONE.PRODUCT_ID);
            return View(iPHONE);
        }

        // POST: IPHONEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SERIAL_NO,PRODUCT_ID,PRODUCT_NAME,PRODUCT_SERIES,PRODUCT_STORAGE,PRODUCT_PROCESSOR")] IPHONE iPHONE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iPHONE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRODUCT_ID = new SelectList(db.APPLEs, "PRODUCT_ID", "ADDRESS", iPHONE.PRODUCT_ID);
            return View(iPHONE);
        }

        // GET: IPHONEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPHONE iPHONE = db.IPHONEs.Find(id);
            if (iPHONE == null)
            {
                return HttpNotFound();
            }
            return View(iPHONE);
        }

        // POST: IPHONEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IPHONE iPHONE = db.IPHONEs.Find(id);
            db.IPHONEs.Remove(iPHONE);
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

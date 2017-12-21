using Assignment2_Part1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Assignment2_Part1.Controllers
{
    [Authorize]
    public class IPHONEsController : Controller
    {


        // repo link
        private IIPHONEsRepository db;

        // if no param passed to constructor, use EF Repository & DbContext
        public IPHONEsController()
        {
            this.db = new EFIPHONEsRepository();
        }
        // if mock repo object passed to constructor, use Mock interface for unit testing
        public IPHONEsController(IIPHONEsRepository smRepo)
        {
            this.db = smRepo;
        }

        // GET: IPHONEs
        public ViewResult Index()
        {
            var iPHONEs = db.iPHONEs;
            return View(iPHONEs.ToList());
        }

        // POST: StoreManager - for Title Search on Index View
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string iphone)
        {
            

            ViewBag.IphoneCount = iphone.Count();
            return View(iphone);
        }

        // GET: IPHONEs/Details/5
        public ViewResult Details(int? productID)
        {
            if(productID == null)
            {
                return View("Error");
            }
            IPHONE iphone = db.iPHONEs.SingleOrDefault(a => a.PRODUCT_ID == productID);
            if (iphone == null)
            {
                return View("Error");
            }
            return View(iphone);
        }

        // GET: IPHONEs/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: IPHONEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SERIAL_NO,PRODUCT_ID,PRODUCT_NAME,PRODUCT_SERIES,PRODUCT_STORAGE,PRODUCT_PROCESSOR")] IPHONE iPhone)
        {
            if (ModelState.IsValid)
            {
                // new repository code for inserting
                db.Save(iPhone);

                return RedirectToAction("Index");

            }
            return View("Create", iPhone);

        }      

        // GET: IPHONEs/Edit/5
        public ViewResult Edit(int? productID)
        {
            if (productID == null)
            {
                return View("Error");
            }
          
            // new repository code replacing line above
            IPHONE iphone = db.iPHONEs.SingleOrDefault(a => a.PRODUCT_ID == productID);

            if (iphone == null)
            {
                return View("Error");
            }
           
            return View(iphone);
        }

        // POST: IPHONEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SERIAL_NO,PRODUCT_ID,PRODUCT_NAME,PRODUCT_SERIES,PRODUCT_STORAGE,PRODUCT_PROCESSOR")] IPHONE iPhone)
        {
            if (ModelState.IsValid)
            {


                // repository code - new
                db.Save(iPhone);

                return RedirectToAction("Index");
            }
            return View("Edit", iPhone);
        }

        // GET: IPHONEs/Delete/5
        public ViewResult Delete(int? productID)
        {
            if (productID == null)
            {
                return View("Error");
            }
            

            // new repository code replacing line above
            IPHONE iphone = db.iPHONEs.SingleOrDefault(a => a.PRODUCT_ID == productID);
            if (iphone == null)
            {
                return View("Error");
            }
            return View(iphone);
        }

        // POST: IPHONEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? productID)
        {
            if (productID == null)
            {
                return View("Error");
            }
            IPHONE iphone = db.iPHONEs.SingleOrDefault(a => a.PRODUCT_ID == productID);
            if (iphone == null)
            {
                return View("Error");
            }

            db.Delete(iphone);

            return RedirectToAction("Index");

            //protected override void Dispose(bool disposing)
            //{
            //    if (disposing)
            //    {
            //        db.Dispose();
            //    }
            //    base.Dispose(disposing);
            //}
        }
}
}

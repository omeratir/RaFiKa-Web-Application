using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RaFiKaWebApplication.Models;

namespace RaFiKaWebApplication.Controllers
{
    public class SuppliersController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: Suppliers
        public ActionResult Index()
        {
            if (Session["Admin"] == "admin")
            {
                return View(db.suppliers.ToList());
            }
            return RedirectToAction("ErrorMessage");
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == "admin")
            {
                return View();
            }
            return RedirectToAction("ErrorMessage");
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierId,NameSupplier,PhoneSupplier,GoodsSupplier")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == "admin")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Supplier supplier = db.suppliers.Find(id);
                if (supplier == null)
                {
                    return HttpNotFound();
                }
                return View(supplier);
            }
            return RedirectToAction("ErrorMessage");
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,NameSupplier,PhoneSupplier,GoodsSupplier")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] == "admin")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Supplier supplier = db.suppliers.Find(id);
                if (supplier == null)
                {
                    return HttpNotFound();
                }
                return View(supplier);
            }
            return RedirectToAction("ErrorMessage");
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.suppliers.Find(id);
            db.suppliers.Remove(supplier);
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

        public ActionResult ErrorMessage()
        {
            return View();
        }
    }
}

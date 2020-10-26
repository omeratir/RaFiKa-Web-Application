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
    public class ProductsController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.SupplierProduct).Include(p => p.TypeOfProduct);
            return View(products.ToList());
        }

        public ActionResult HighHeel()
        {
            var products = db.products.Include(p => p.SupplierProduct).Include(p => p.TypeOfProduct);
            List<Product> temp = products.ToList();
            List<Product> highHeels = new List<Product>();

            foreach (Product item in temp)
            {
                if (item.TypeOfProduct.NameProductType.Equals("High Heel"))
                    highHeels.Add(item);
            }
            return View(highHeels);
        }

        public ActionResult Sandals()
        {
            var products = db.products.Include(p => p.SupplierProduct).Include(p => p.TypeOfProduct);
            List<Product> temp = products.ToList();
            List<Product> sandals = new List<Product>();

            foreach (Product item in temp)
            {
                if (item.TypeOfProduct.NameProductType.Equals("Sandals"))
                    sandals.Add(item);
            }
            return View(sandals);
        }

        public ActionResult Sneakers()
        {
            var products = db.products.Include(p => p.SupplierProduct).Include(p => p.TypeOfProduct);
            List<Product> temp = products.ToList();
            List<Product> sneakers = new List<Product>();

            foreach (Product item in temp)
            {
                if (item.TypeOfProduct.NameProductType.Equals("Sneakers"))
                    sneakers.Add(item);
            }
            return View(sneakers);
        }

        public ActionResult Boots()
        {
            var products = db.products.Include(p => p.SupplierProduct).Include(p => p.TypeOfProduct);
            List<Product> temp = products.ToList();
            List<Product> boots = new List<Product>();

            foreach (Product item in temp)
            {
                if (item.TypeOfProduct.NameProductType.Equals("Boots"))
                    boots.Add(item);
            }
            return View(boots);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == "admin")
            {
                ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "NameSupplier");
                ViewBag.ProductTypeId = new SelectList(db.typesshoes, "ProductTypeId", "NameProductType");
                return View();
            }

            return RedirectToAction("ErrorMessage");
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,NameProduct,ProductTypeId,SizeProduct,PriceProduct,PicProduct,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "NameSupplier", product.SupplierId);
            ViewBag.ProductTypeId = new SelectList(db.typesshoes, "ProductTypeId", "NameProductType", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == "admin")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "NameSupplier", product.SupplierId);
                ViewBag.ProductTypeId = new SelectList(db.typesshoes, "ProductTypeId", "NameProductType", product.ProductTypeId);
                return View(product);
            }
            return RedirectToAction("ErrorMessage");
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,NameProduct,ProductTypeId,SizeProduct,PriceProduct,PicProduct,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "NameSupplier", product.SupplierId);
            ViewBag.ProductTypeId = new SelectList(db.typesshoes, "ProductTypeId", "NameProductType", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] == "admin")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            return RedirectToAction("ErrorMessage");
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.products.Find(id);
            db.products.Remove(product);
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

        public ActionResult ProdJoinType()
        {
            return View();
        }

        public ActionResult priceAvg()
        {
            var products = db.products.Include(p => p.SupplierProduct).Include(p => p.TypeOfProduct);
            return View(products.ToList());

        }

        public ActionResult sizeAvg()
        {
            var products = db.products.Include(p => p.SupplierProduct).Include(p => p.TypeOfProduct);
            return View(products.ToList());

        }

    }
}
